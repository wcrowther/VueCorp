using Microsoft.IdentityModel.Tokens;
using coreApi.Logic.Interfaces;
using coreApi.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace coreApi.Logic.Managers
{
	public class AuthManager : IAuthManager
    {
        private readonly AppSettings _appSettings;
		private readonly IUserManager _userManager;

		public AuthManager(AppSettings appSettings, IUserManager userManager) 
        {
            _appSettings = appSettings;
			_userManager = userManager;
		}

		public AuthResponse Authenticate(AuthRequest model)
		{
			var user = _userManager.GetUserByUsername(model.UserName);

			// return null if user not found
			if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
				return null;

			// authentication successful so generate jwt token

			var expires = DateTime.UtcNow.AddDays(7);
			var authResponse = new AuthResponse(user, expires);
			authResponse.Token  = GenerateJwt(authResponse, user.Roles);

			return authResponse;
		}

		public AuthResponse Signup(AuthSignup model)
		{
			var existingUser = _userManager.GetUserByUsername(model.UserName);

			// Cannot sign up new user with existing username / email
			if (existingUser is not null)
				return null;

			string passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
			var newUser = _userManager.CreateNewUser(model, passwordHash);

			var expires			= DateTime.UtcNow.AddDays(7);
			var authResponse	= new AuthResponse(newUser, expires);
			authResponse.Token  = GenerateJwt(authResponse, newUser.Roles);

			return authResponse;
		}

		// ============================================================================

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

            var key     = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.AuthSigningKey));
            var creds   = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var token   = new JwtSecurityToken
            (
				claims:				baseClaims,
				issuer:				_appSettings.AuthIssuer,
                audience:           _appSettings.AuthAudience,
                expires:            DateTime.Now.AddMinutes(20),
                signingCredentials: creds
            );

			var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
