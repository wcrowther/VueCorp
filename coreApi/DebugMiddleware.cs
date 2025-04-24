using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace coreApi
{
	public class DebugMiddleware
	{
		private readonly RequestDelegate _next;

		public DebugMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			// Useful for intercepting the raw request, especially if model binding, etc. goes wrong and controller method is not hit...
			Debug.WriteLine($"Request for {httpContext.Request.Path} received ({httpContext.Request.ContentLength ?? 0} bytes)");

			// Call the next middleware delegate in the pipeline 
			await _next.Invoke(httpContext);
		}
	}
}

// USAGE:
// if (env.IsDevelopment() )
// {
//		app.UseMiddleware<DebugMiddleware>();
// }

