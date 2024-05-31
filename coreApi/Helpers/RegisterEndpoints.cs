using LinqKit;

namespace coreApi.Helpers;

public static class EndpointHelper
{
	public static void RegisterEndpoints(this WebApplication app)
	{
		var staticMethods = typeof(Endpoints).GetMethods().Where(a => a.IsStatic && a.IsPublic);

		staticMethods.ForEach(a => a.Invoke(null, [app]));
	}
}
