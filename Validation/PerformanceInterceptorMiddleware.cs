using System.Diagnostics;
using System.Text;

namespace GraphQL_API.Validation
{
    public class PerformanceInterceptorMiddleware : HttpClientHandler
    {
        private readonly RequestDelegate _next;
		private Stopwatch? _timer;
		private long _memory;
		private readonly TimeSpan _timeout;

		public PerformanceInterceptorMiddleware(RequestDelegate next, TimeSpan timeout)
        {
            _next = next;
			_timeout = timeout;
        }

		public async Task InvokeAsync(HttpContext context)
		{
			context.Request.EnableBuffering();
			string requestBody = "";
			_timer = Stopwatch.StartNew();
			_memory = GC.GetTotalMemory(false); // Get memory before execution

			using (var cts = new CancellationTokenSource(_timeout))
			{
				try
				{
					await _next(context).WithCancellation(cts.Token); // Call the next middleware in the pipeline
				}
				catch (OperationCanceledException) when (!context.RequestAborted.IsCancellationRequested)
				{
					context.Request.Body.Position = 0; // Rewind the request body
					using (StreamReader reader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 1024, true))
					{
						requestBody = await reader.ReadToEndAsync(); // Read the request body
					}

					throw new Exception("Operation Took Too Long");
				}
			}

			_timer.Stop();
			var elapsedMs = _timer.ElapsedMilliseconds;
			var memoryUsed = GC.GetTotalMemory(false) - _memory; // Calculate memory used

			// Log the results
			Console.WriteLine($"Execution Time: {elapsedMs} ms");
			Console.WriteLine($"Memory Used: {memoryUsed} bytes");
		}
	}
}
