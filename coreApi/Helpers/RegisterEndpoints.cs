using System.Diagnostics;

namespace coreApi.Helpers;

public static class EndpointHelper
{
	// Add an EndPoints static partial named for the MapGroup and it will be 
	// registered by this helper. See existing examples in the Endpoints folder.

	public static void RegisterMyEndpoints(this WebApplication app)
	{
		var staticMethods = typeof(Endpoints).GetMethods().Where(a => a.IsStatic && a.IsPublic);

		foreach (var method in staticMethods)
		{
			Debug.WriteLine($"Adding Endpoint {method.Name}");
			method.Invoke(null, [app]);
		}
	}
}


// One liner version -> staticMethods.ForEach(a => a.Invoke(null, [app]));
