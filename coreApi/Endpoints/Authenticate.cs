using coreApi.Helpers;
using coreApi.Models;
using coreLogic.Interfaces;
using coreLogic.Models;
using coreLogic.Models.Generic;
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

		// login
        auth.MapPost("/login", (	AuthRequest model, 
									IAuthManager _authManager) =>
        {
            Returns<AuthUser> returns = _authManager.Authenticate(model);

			return	returns.Success
					? Results.Ok(returns.Data)
					: Results.Unauthorized();
		})
		.Validate<AuthRequest>(false)
        .WithName("Login");

		// signup
		auth.MapPost("/signup", (		UserToCreate model, 
										IAuthManager _authManager,
										HttpContext httpContext) =>
		{
			Returns<AuthUser> returns = _authManager.Signup(model, httpContext);

			return	returns.Success 
					? Results.Ok(returns.Data) 
					: Results.BadRequest(returns.Fault.Message);
		})
		.Validate<UserToCreate>(false)
		.WithName("Signup");

		// refreshAuth
		auth.MapPost("/refreshAuth", (	AuthRefreshRequest request, 
										IAuthManager _authManager,
										HttpContext httpContext  ) =>
		{
			Returns<AuthUser> returns = _authManager.RefreshAuth(request, httpContext);

			return	returns.Success 
					? Results.Ok(returns.Data) 
					: Results.BadRequest(returns.Fault.Message);
		})
		.Validate<AuthRefreshRequest>(false)
		.WithName("RefreshAuth");
	}
}

