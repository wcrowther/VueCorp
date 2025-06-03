﻿using coreApi.Models;
using coreLogic.Adapters;
using coreLogic.Helpers;
using coreLogic.Interfaces;
using coreLogic.Models;
using coreLogic.Models.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Xml;
using WildHare.Extensions;
using static System.Environment;

namespace coreLogic.Managers;

public class AuthManager(	IUserManager userManager,
							ITokenManager tokenManager,
							IUserClaimsManager userClaimsManager,
							ILogger<AuthManager> logger,
							IHttpContextAccessor accessor,
							AppSettings appSettings
						)
: IAuthManager
{
	public Returns<User> GetCurrentUser()
	{
		string userName = userClaimsManager.GetCurrentUsername();
		var user		= userName.IsNullOrEmpty() ? null : userManager.GetUserByUsername(userName);

		return Returns<User>.Result(user, "Not able to get the current user.");	
	}

	public Returns<AuthUser> Authenticate(AuthRequest authRequest)
	{
		var user = userManager.GetUserByUsername(authRequest.UserName);

		if (user == null || !BCrypt.Net.BCrypt.Verify(authRequest.Password, user.PasswordHash))
		{
			string attemptHash	= BCrypt.Net.BCrypt.HashPassword(authRequest.Password);
			string message		= $"Not able to authenticate user {authRequest.UserName}. ";
			string techMessage	= user is  null 
								  ? "UserName not found in database."
								  : $"Password incorrect. AttemptHash: {attemptHash}.";

			logger.LogInformation(message + NewLine + techMessage);

			return Returns<AuthUser>.Failure(message);
		}

		// 2FA check
		if (user.IsTwoFactorEnabled)
		{
			if (string.IsNullOrWhiteSpace(authRequest.TwoFactorCode) ||
				!TotpHelper.ValidateTotp(user.TwoFactorSecret, authRequest.TwoFactorCode))
			{
				return Returns<AuthUser>.Failure("Two-factor authentication code required or invalid.");
			}
		}

		logger.LogInformation($"AuthManager.Authenticate user '{authRequest.UserName}'");

		user = userManager.UpdateUserRefreshToken(user);

		return Returns<AuthUser>.Result(GetAuthResponse(user));
	}

	public Returns<AuthUser> Signup(UserToCreate userToCreate)
	{
		var existingUser = userManager.GetUserByUsername(userToCreate.UserName);

		if (existingUser is not null)
			return new Error($"Not able to sign up user {userToCreate.UserName}");

		var user			= userManager.CreateUser(userToCreate);
		var authResponse	= GetAuthResponse(user);

		return Returns<AuthUser>.Result(authResponse);
	}

	public Returns<AuthUser> RefreshAuth(AuthRefreshRequest request)
	{
		var user			= userManager.GetUserById(request.UserId);
		var refreshToken	= accessor.HttpContext.Request.Cookies["RefreshToken"];
		var domain			= accessor.HttpContext.Request.Headers.Origin.ToString();
		var allowedDomains  = appSettings.AllowedOrigins.Split(";", true);

		if (!IsAllowedDomain(domain, allowedDomains))
			return AuthUserOrError.Failure("Not able to refresh token from this domain");

		if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiration <= DateTime.Now)
			return Returns<AuthUser>.Failure($"Not able to refresh token for userId: {request.UserId}");

		user = userManager.UpdateUserRefreshToken(user);

		var (token, expiration) = tokenManager.GenerateJwtToken(user);

		logger.LogInformation($"AuthManager.RefreshAuth refresh user: '{user.UserName}'");

		return Returns<AuthUser>.Result(user.ToAuthResponse(token, expiration));
	}

	// ============================================================================

	private AuthUser GetAuthResponse(User user)
	{
		if (user is null)
			return null;

		var (token, tokenExpiration) = tokenManager.GenerateJwtToken(user);

		return new AuthUser(user, token, tokenExpiration);
	}

	private static bool IsAllowedDomain(string domain, string[] allowedDomains)
	{
		if (allowedDomains?[0] == "*")  // '*' allows all
			return true;

		return allowedDomains.Any(a => a.Equals(domain,StringComparison.OrdinalIgnoreCase));
	}
}
