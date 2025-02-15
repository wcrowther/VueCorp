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
	public AuthUser Authenticate(AuthRequest authRequest)
	{
		var user = userManager.GetUserByUsername(authRequest.UserName);

		if (user == null || !Verifier.Verify(authRequest.Password, user.PasswordHash))
		{
			logger.LogInformation($"Authenticating user not found for: '{authRequest.UserName}'");

			return null;
		}

		logger.LogInformation($"AuthManager.Authenticate user '{authRequest.UserName}'");

		return GetAuthResponse(user);
	}

	public Returns<AuthUser> Signup(UserToCreate userToCreate)
	{
		var existingUser = userManager.GetUserByUsername(userToCreate.UserName);

		if (existingUser is not null)
			return Returns<AuthUser>.Error($"Not able to sign up user {userToCreate.UserName}");

		var user = userManager.CreateUser(userToCreate);
		var authResponse = GetAuthResponse(user);

		return Returns<AuthUser>.Ok(authResponse);
	}

	public Returns<AuthUser> RefreshAuth(AuthRefreshRequest request, HttpContext httpContext)
	{
		var user = userManager.GetUserById(request.UserId);

		if (user == null || user.RefreshToken != request.RefreshToken || user.RefreshTokenExpiration <= DateTime.Now)
			return Returns<AuthUser>.Error($"Not able to refresh token for userId: {request.UserId}");

		user = userManager.UpdateUserRefreshToken(user, httpContext);

		var (token, expiration) = tokenManager.GenerateJwtToken(user);

		logger.LogInformation($"AuthManager.RefreshAuth refresh user: '{user.UserName}'");

		return user.ToAuthResponse(token, expiration);
	}

	// ============================================================================

	private AuthUser GetAuthResponse(User user)
	{
		if (user is null)
			return null;

		var (token, tokenExpiration) = tokenManager.GenerateJwtToken(user);

		return new AuthUser(user, token, tokenExpiration);
	}
}
