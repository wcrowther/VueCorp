using coreApi.Helpers;
using coreApi.Models;
using coreLogic.Interfaces;
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
            AuthResponse result = _authManager.Authenticate(model);

			return	result == null 
					? Results.Unauthorized() 
					: Results.Ok(result);
		})
		.Validate<AuthRequest>(false)
        .WithName("Authenticate");


		auth.MapPost("/signup", (UserToCreate model, IAuthManager _authManager) =>
		{
			var result = _authManager.Signup(model);

			if (result.Success)
				return Results.Ok(result.Data);

			return Results.BadRequest(result.Exception.Message);
		})
		.Validate<UserToCreate>(false)
		.WithName("Signup");
	}
}

