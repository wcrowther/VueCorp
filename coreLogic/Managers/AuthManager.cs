using coreApi.Models;
using coreLogic.Adapters;
using coreLogic.Interfaces;
using coreLogic.Models;
using coreLogic.Models.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using Verifier = BCrypt.Net.BCrypt;

namespace coreLogic.Managers;

public class AuthManager(	IUserManager userManager,
							ITokenManager tokenManager,
							ILogger<AuthManager> logger
						)
: IAuthManager
{
	public AuthResponse Authenticate(AuthRequest model)
	{
		var user = userManager.GetUserByUsername(model.UserName);

		if (user == null || !Verifier.Verify(model.Password, user.PasswordHash))
		{
			logger.LogInformation($"Authenticating user not found for: '{model.UserName}'");

			return null;
		}

		logger.LogInformation($"AuthManager.Authenticate user '{model.UserName}'");

		return GetAuthResponse(user);
	}

	public Returns<AuthResponse> Signup(UserToCreate userToCreate)
	{
		var existingUser = userManager.GetUserByUsername(userToCreate.UserName);

		if (existingUser is not null)
			return Returns<AuthResponse>.Error($"Not able to sign up user {userToCreate.UserName}");

		var user = userManager.CreateUser(userToCreate);
		var authResponse = GetAuthResponse(user);

		return Returns<AuthResponse>.Ok(authResponse);
	}

	public Returns<AuthResponse> RefreshAuth(AuthRefreshRequest request, HttpContext httpContext)
	{
		var user = userManager.GetUserById(request.UserId);

		if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiration <= DateTime.Now)
			return Returns<AuthResponse>.Error($"Not able to refresh token for userId: {request.UserId}");

		user = userManager.UpdateUserRefreshToken(user, httpContext);

		var token = tokenManager.GenerateJwt(user);

		logger.LogInformation($"AuthManager.RefreshAuth refresh user: '{user.UserName}'");

		return user.ToAuthResponse(token);
	}

	// ============================================================================

	private AuthResponse GetAuthResponse(User user)
	{
		if (user is null)
			return null;

		var token = tokenManager.GenerateJwt(user);

		return new AuthResponse(user, token);
	}
}
