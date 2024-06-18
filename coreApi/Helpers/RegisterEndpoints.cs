using LinqKit;

namespace coreApi.Helpers;

public static class EndpointHelper
{
	// Add an EndPoints static partial named for the MapGroup and it will be 
	// registered by this helper. See existing examples in the Endpoints folder.

	public static void RegisterEndpoints(this WebApplication app)
	{
		var staticMethods = typeof(Endpoints).GetMethods().Where(a => a.IsStatic && a.IsPublic);

		staticMethods.ForEach(a => a.Invoke(null, [app]));
	}
}
