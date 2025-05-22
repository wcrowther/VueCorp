using coreApi.Models;
using coreLogic.Helpers;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using WildHare.Extensions;

namespace coreApi
{
	public class DebugMiddleware
	{
		private readonly RequestDelegate _next;

		public DebugMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext, AppSettings appSettings)
		{
			bool showJsonPostDebug = appSettings.ShowJsonPostDebug;

			// Useful for intercepting the raw request, especially if model binding, etc. goes wrong...
			Debug.WriteLine($"Request for {httpContext.Request.Path} received ({httpContext.Request.ContentLength ?? 0} bytes)");

			if (showJsonPostDebug && httpContext.Request.Method == HttpMethods.Post && IsJsonRequest(httpContext))
			{
				// Enable buffering so the body can be read multiple times
				httpContext.Request.EnableBuffering();

				// Read the request body stream as string
				httpContext.Request.Body.Position = 0;

				using var reader = new StreamReader
				(
					httpContext.Request.Body,
					encoding:							Encoding.UTF8,
					detectEncodingFromByteOrderMarks:	false,
					bufferSize:							1024,
					leaveOpen:							true  // leave it open
				);

				var body = await reader.ReadToEndAsync();

				// Reset the stream position for the next middleware/controller
				httpContext.Request.Body.Position = 0;

				Debug.WriteLine($"Request Json Body: {body.MaskJsonSecrets("password")}");
				Debug.WriteLine("-".Repeat(70));
			}

			// Call the next middleware delegate in the pipeline 
			await _next.Invoke(httpContext);
		}

		private static bool IsJsonRequest(HttpContext httpContext)
		{
			return httpContext.Request.ContentType?.Contains("application/json", StringComparison.OrdinalIgnoreCase) == true;
		}

		private static bool SanitizeJson(HttpContext httpContext)
		{
			return httpContext.Request.ContentType?.Contains("application/json", StringComparison.OrdinalIgnoreCase) == true;
		}
	}
}

// USAGE:
// if (env.IsDevelopment() )
// {
//		app.UseMiddleware<DebugMiddleware>();
// }

