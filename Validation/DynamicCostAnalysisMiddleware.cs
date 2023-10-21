using Microsoft.Extensions.Options;
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

		//public DynamicCostAnalysisMiddleware(RequestDelegate next, IOptions<DynamicCostAnalysisMiddlewareOptions> options)
		//{
		//	_next = next;
		//	_timeout = options.Value.Timeout;
		//	_memoryLimitMB = options.Value.MemoryLimitMB;
		//}

		public async Task InvokeAsync(HttpContext context)
		{
			context.Request.EnableBuffering();
			string requestBody = "";

			context.Request.Body.Position = 0;
			using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
			{
				requestBody = await reader.ReadToEndAsync();
			}
			context.Request.Body.Position = 0;

			_timer = Stopwatch.StartNew();
			_memory = GC.GetTotalMemory(false);

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
							throw new Exception("Memory Limit Exceeded");
						}
					}
					catch (OperationCanceledException) when (!context.RequestAborted.IsCancellationRequested)
					{
						_timer.Stop();
						_ = Task.Run(() => SaveBannedQuery(requestBody, _timer.ElapsedMilliseconds, GC.GetTotalMemory(false) - _memory, "Elapsed Time"));

						throw new Exception("Operation Took Too Long");
					}
				}
			}
			_timer.Stop();
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
			using (StreamWriter sw = File.AppendText("./Logs/BannedQueryLog.txt"))
			{
				sw.WriteLine("execution time: {0}, \tmemory usage: {1}, \tbanned reason: {2}, \tquery: {3}",
				 executionTime,
				 memoryUsage,
				 reason,
				 query);
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