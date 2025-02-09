using Microsoft.IdentityModel.Tokens;
using coreApi.Logic.Interfaces;
using coreApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using coreLogic.Models.Generic;
using Verifier = BCrypt.Net.BCrypt;
using Microsoft.Extensions.Logging;

namespace coreApi.Logic.Managers
{
	public class AuthManager(AppSettings appSettings, 
							 IUserManager userManager,
							 ILogger<AuthManager> logger) 
		: IAuthManager
    {
		public AuthResponse Authenticate(AuthRequest model)
		{
			var user = userManager.GetUserByUsername(model.UserName);

			if (user == null || !Verifier.Verify(model.Password, user.PasswordHash))
			{
				logger.LogInformation($"Info: Authenticating user not found for: '{model.UserName}'");

				return null;
			}

			logger.LogInformation($"Info: Authenticated user '{model.UserName}'");

			return GetAuthResponse(user);
		}

		public Returns<AuthResponse> Signup(UserCreate newUser)
		{
			var existingUser = userManager.GetUserByUsername(newUser.UserName);

			if (existingUser is not null)
				return Returns<AuthResponse>.Error($"Not able to sign up user {newUser.UserName}");

			var user = userManager.CreateUser(newUser);
			var authResponse = GetAuthResponse(user);

			return Returns<AuthResponse>.Ok(authResponse);
		}

		// ============================================================================

		private AuthResponse GetAuthResponse(User user)
		{
			var expires			= DateTime.UtcNow.AddDays(7);
			var authResponse	= new AuthResponse(user, expires);
			authResponse.Token  = GenerateJwt(authResponse, user.Role);

			return authResponse;
		}

		private string GenerateJwt(AuthResponse authResponse, string userRoles)
        {
			var baseClaims = new List<Claim>()
            {
                new (JwtRegisteredClaimNames.Sub,        authResponse.UserName),
                new (JwtRegisteredClaimNames.Jti,        Guid.NewGuid().ToString()),
                new (JwtRegisteredClaimNames.UniqueName, authResponse.UserName),
			};

			var options		= StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;
			var roleClaims	= userRoles.Split(',', options).Select(s => new Claim(ClaimTypes.Role, s));

			baseClaims.AddRange(roleClaims);

            var key     = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.AuthSigningKey));
            var creds   = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token   = new JwtSecurityToken
            (
				claims:				baseClaims,
				issuer:				appSettings.AuthIssuer,
                audience:           appSettings.AuthAudience,
                expires:            DateTime.Now.AddMinutes(20),
                signingCredentials: creds
            );

			return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
