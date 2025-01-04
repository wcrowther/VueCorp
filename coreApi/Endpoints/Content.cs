using coreApi.Helpers;
using coreApi.Logic.Interfaces;
using coreApi.Models;
using coreLogic.Interfaces;
using coreLogic.Models;
using WildHare.Extensions;

namespace coreApi;

public static partial class Endpoints
{
	public static void ContentEndpoints(this WebApplication app)
	{
		var auth = app.MapGroup("/v1/content")
					  .WithOpenApi()
					  .WithTags("Content");

		auth.MapPost("/getimages", (IContentManager _contentManager) =>
		{
			var result = _contentManager.GetImages();

			return result == null ?
					Results.Unauthorized() :
					Results.Ok(result);
		})
		.WithName("GetImages");
	}
}