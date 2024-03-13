using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using coreApi.Models;
using coreApi.Logic.Interfaces;
using Microsoft.IdentityModel.Tokens;
using WildHare.Extensions;
using coreApi.Helpers;

namespace coreApi.Endpoints;

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
                return Results.Forbid();

            return Results.Ok(response);
        })
		.Validate<AuthRequest>(false)
        .WithName("Authenticate");


		auth.MapPost("/signup", (AuthSignup model, IAuthManager _authManager) =>
		{
			var response = _authManager.Signup(model);

			if (response == null)
				return Results.BadRequest(new { detail = $"Not able to Sign Up {model?.UserName.IfNullOrEmpty("Null User")}." });

			return Results.Ok(response);	
		})
		.Validate<AuthSignup>(false)
		.WithName("Signup");
	}
}

