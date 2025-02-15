using coreApi.Helpers;
using coreApi.Models;
using coreLogic.Interfaces;
using coreLogic.Models;
using System.Runtime.CompilerServices;
using WildHare.Extensions;

namespace coreApi;

public static partial class Endpoints
{
    public static void AuthenticateEndpoints(this WebApplication app)
    {
        var auth = app.MapGroup("/v1/authenticate")
                      .WithOpenApi()
					  .WithTags("Authenticate");

        auth.MapPost("/login", (AuthRequest model, IAuthManager _authManager) =>
        {
            AuthUser result = _authManager.Authenticate(model);

			return	result == null 
					? Results.Unauthorized() 
					: Results.Ok(result);
		})
		.Validate<AuthRequest>(false)
        .WithName("Authenticate");


		auth.MapPost("/signup", (UserToCreate model, IAuthManager _authManager) =>
		{
			var result = _authManager.Signup(model);

			return	result.Success 
					? Results.Ok(result.Data) 
					: Results.BadRequest(result.Exception.Message);
		})
		.Validate<UserToCreate>(false)
		.WithName("Signup");


		auth.MapPost("/refreshAuth", (	AuthRefreshRequest request, 
										IAuthManager _authManager,
										HttpContext httpContext  ) =>
		{
			var result = _authManager.RefreshAuth(request, httpContext);

			return	result.Success 
					? Results.Ok(result.Data) 
					: Results.BadRequest(result.Exception.Message);
		})
		.Validate<AuthRefreshRequest>(false)
		.WithName("RefreshAuth");
	}
}

