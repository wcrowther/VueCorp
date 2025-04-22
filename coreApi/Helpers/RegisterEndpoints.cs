using System.Diagnostics;

namespace coreApi.Helpers;

public static class EndpointHelper
{
	// Add an EndPoints static partial named for the MapGroup and it will be 
	// registered by this helper. See existing examples in the Endpoints folder.
	// 'No action descriptors found...' warning can be ignored as it is for Controller routes.

	public static void RegisterMyEndpoints(this WebApplication app)
	{
		var staticMethods = typeof(Endpoints).GetMethods().Where(a => a.IsStatic && a.IsPublic);

		// For logging: var logger = app.Services.GetRequiredService<ILogger<Program>>();

		foreach (var method in staticMethods)
		{
			// logger.LogInformation($"Adding Route Endpoint {method.Name}");

			Debug.WriteLine($"Adding Endpoint {method.Name}");

			method.Invoke(null, [app]);
		}
	}
}
