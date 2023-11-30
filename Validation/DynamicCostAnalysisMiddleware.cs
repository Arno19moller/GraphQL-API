using System.Diagnostics;
using System.Text;
using RequestDelegate = Microsoft.AspNetCore.Http.RequestDelegate;

namespace GraphQL_API.Validation
{
	public class DynamicCostAnalysisMiddleware : HttpClientHandler
	{
		private readonly int _memoryLimitMB;
		private readonly RequestDelegate _next;
		private readonly TimeSpan _timeout;
		private long _memory;
		private Stopwatch? _timer;

		public DynamicCostAnalysisMiddleware(RequestDelegate next, TimeSpan timeout, int memoryLimitMB)
		{
			_next = next;
			_timeout = timeout;
			_memoryLimitMB = memoryLimitMB;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			//Stopwatch _timer = Stopwatch.StartNew();
			//long _memory = GC.GetTotalMemory(false);

			try
			{
				context.Request.EnableBuffering();
				string requestBody = "";

				context.Request.Body.Position = 0;
				using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
				{
					requestBody = await reader.ReadToEndAsync();
				}
				context.Request.Body.Position = 0;

				if (IsIntrospectionQuery(requestBody))
				{
					await _next(context);
				}
				else
				{
					using (var cts = new CancellationTokenSource(_timeout))
					{
						try
						{
							await _next(context).WithCancellation(cts.Token);

							if (GC.GetTotalMemory(false) - _memory > _memoryLimitMB)
							{
								_timer.Stop();
								_ = Task.Run(() => SaveBannedQuery(requestBody, _timer.ElapsedMilliseconds, GC.GetTotalMemory(false) - _memory, "Memory Exceeded"));
							}
						}
						catch (OperationCanceledException) when (!context.RequestAborted.IsCancellationRequested)
						{
							_timer.Stop();
							_ = Task.Run(() => SaveBannedQuery(requestBody, _timer.ElapsedMilliseconds, GC.GetTotalMemory(false) - _memory, "Elapsed Time"));

							throw new Exception("Operation Took Too Long");
						}
						catch (Exception ex)
						{
							_timer.Stop();
						}
					}
				}
			}
			catch (Exception ex)
			{
				_ = Task.Run(() => SaveExecutionTelemetry(_timer!.ElapsedMilliseconds, GC.GetTotalMemory(false) - _memory, false));
				throw;
			}
			//await _next(context);
			finally
			{
				if (_timer!.IsRunning)
				{
					_timer.Stop();
				}
			_ = Task.Run(() => SaveExecutionTelemetry(_timer.ElapsedMilliseconds, GC.GetTotalMemory(false) - _memory, true));
			}
		}

		private bool IsIntrospectionQuery(string query)
		{
			return query.Contains("__schema") ||
				   query.Contains("__type") ||
				   query.Contains("__typename") ||
				   query.Contains("__typeKind") ||
				   query.Contains("__field") ||
				   query.Contains("__inputValue") ||
				   query.Contains("__enumValue") ||
				   query.Contains("__directive");
		}

		private void SaveBannedQuery(string query, long executionTime, long memoryUsage, string reason)
		{
			var memoryUsageMB = (decimal)memoryUsage / 1048576M;
			var executionTimeSeconds = (decimal)executionTime / 1000M;

			using (StreamWriter sw = File.AppendText("./Logs/BannedQueryLog.txt"))
			{
				sw.WriteLine("execution time: {0}, \t\tmemory usage: {1}, \t\tbanned reason: {2}, \t\tquery: {3}",
				 executionTimeSeconds,
				 memoryUsageMB,
				 reason,
				 query);
				sw.WriteLine("=====================================================================================");
			}
		}

		private void SaveExecutionTelemetry(long executionTime, long memoryUsage, bool success)
		{
			//var mb = Math.Pow(1024, 2);
			var memoryUsageMB = (decimal)memoryUsage / 1048576M;
			var executionTimeSeconds = (decimal)executionTime / 1000M;

			using (StreamWriter sw = File.AppendText("./Logs/ExecutionTelemetry.txt"))
			{
				sw.WriteLine("execution time: {0}s \t\tmemory usage: {1}mb \t\tsuccess: {2}",
				 Decimal.Round(executionTimeSeconds, 8),
				 Decimal.Round(memoryUsageMB, 8),
				 success);
				sw.WriteLine("=====================================================================================");
			}
		}
	}

	public static class DynamicCostAnalysisMiddlewareExtensions
	{
		public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<DynamicCostAnalysisMiddleware>();
		}
	}

	public class DynamicCostAnalysisMiddlewareOptions
	{
		public TimeSpan Timeout { get; set; }
		public int MemoryLimitMB { get; set; }
	}
}