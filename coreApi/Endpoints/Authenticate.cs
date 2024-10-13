using coreApi.Helpers;
using coreApi.Logic.Interfaces;
using coreApi.Models;
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

            if (result == null)
                return Results.Unauthorized();

            return Results.Ok(result);
        })
		.Validate<AuthRequest>(false)
        .WithName("Authenticate");


		auth.MapPost("/signup", (UserCreate model, IAuthManager _authManager) =>
		{
			var result = _authManager.Signup(model);

			if (result.Success)
				return Results.Ok(result.Data);

			return Results.BadRequest(result.Message);
		})
		.Validate<UserCreate>(false)
		.WithName("Signup");
	}
}

