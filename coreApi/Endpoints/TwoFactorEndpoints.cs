using coreApi.Models;
using coreLogic.Helpers;
using coreLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace coreApi;

public static partial class Endpoints
{
    public static void TwoFactorEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/v1/2fa")
            .RequireAuthorization()
            .WithOpenApi()
            .WithTags("TwoFactor");

        // Enable 2FA: generates a secret and returns it (for QR code)
        endpoints.MapPost("/enable", ([FromServices] IUserManager userManager, HttpContext httpContext) =>
        {
            var username = httpContext.User.Identity?.Name;
            var dbUser = userManager.GetUserByUsername(username);

            if (dbUser == null) return 
				Results.Unauthorized();

            if (dbUser.IsTwoFactorEnabled) return 
				Results.BadRequest("2FA already enabled.");

            dbUser.TwoFactorSecret = TotpHelper.GenerateBase32Secret();
            userManager.SaveUser(dbUser);

            return Results.Ok(new { secret = dbUser.TwoFactorSecret });
        });

        // Verify 2FA: user submits code to confirm setup
        endpoints.MapPost("/verify", ([FromServices] IUserManager userManager, HttpContext httpContext, [FromBody] string code) =>
        {
            var username = httpContext.User.Identity?.Name;
            var dbUser = userManager.GetUserByUsername(username);

            if (dbUser == null || string.IsNullOrEmpty(dbUser.TwoFactorSecret)) 
				return Results.Unauthorized();

            if (!TotpHelper.ValidateTotp(dbUser.TwoFactorSecret, code)) 
				return Results.BadRequest("Invalid code.");

            dbUser.IsTwoFactorEnabled = true;
            userManager.SaveUser(dbUser);

            return Results.Ok("2FA enabled.");
        });

        // Disable 2FA
        endpoints.MapPost("/disable", ([FromServices] IUserManager userManager, HttpContext httpContext) =>
        {
            var username = httpContext.User.Identity?.Name;
            var dbUser = userManager.GetUserByUsername(username);

            if (dbUser == null) 
				return Results.Unauthorized();

            dbUser.IsTwoFactorEnabled = false;
            dbUser.TwoFactorSecret = null;
            userManager.SaveUser(dbUser);

            return Results.Ok("2FA disabled.");
        });
    }
}
