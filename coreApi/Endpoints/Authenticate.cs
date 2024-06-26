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
            AuthResponse response = _authManager.Authenticate(model);

            if (response == null)
                return Results.Unauthorized();

            return Results.Ok(response);
        })
		.Validate<AuthRequest>(false)
        .WithName("Authenticate");


		auth.MapPost("/signup", (UserCreate model, IAuthManager _authManager) =>
		{
			var response = _authManager.Signup(model);

			if (!response.Success)
				return Results.BadRequest(response.Message);

			return Results.Ok(response.Data);	
		})
		.Validate<UserCreate>(false)
		.WithName("Signup");
	}
}

