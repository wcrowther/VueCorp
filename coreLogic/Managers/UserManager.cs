using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Data.Interfaces;
using coreLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using bCrypt = BCrypt.Net.BCrypt;

namespace coreLogic.Managers;

public class UserManager(	IUserRepo userRepo,
							ICookieManager cookieManager,
							ITokenManager tokenManager)
: IUserManager
{
	public IEnumerable<User> GetAllUsers()
	{
		return userRepo.GetAllUsers();
	}

	public User GetUserByUsername(string username)
	{
		return userRepo.GetUserByUserName(username);
	}

	public User GetUserById(int id)
	{
		return userRepo.GetUserById(id);
	}

	public User CreateUser(UserToCreate model, string passwordHash)
	{
		return userRepo.CreateUser(model, passwordHash);
	}

	public PagedList<User> GetPagedUsers(Pager pager)
	{
		pager ??= new Pager();

		return userRepo.GetPagedUsers(pager);
	}

	public User SaveUser(User user)
	{
		userRepo.SaveUser(user);

		return user;
	}

	public User CreateUser(UserToCreate userToCreate, HttpContext httpContext)
	{
		var (token, expiration) = tokenManager.GenerateRefreshTokenAndExpiration();

		userToCreate.RefreshToken           = token;
		userToCreate.RefreshTokenExpiration = expiration;

		string passwordHash = bCrypt.HashPassword(userToCreate.Password);

		var createdUser = userRepo.CreateUser(userToCreate, passwordHash);

		cookieManager.SetRefreshTokenCookie(createdUser.RefreshToken, httpContext);

		return createdUser;
	}

	public User UpdateUserRefreshToken(User user, HttpContext httpContext)
	{
		var (token, expiration) = tokenManager.GenerateRefreshTokenAndExpiration();

		user.RefreshToken           = token;
		user.RefreshTokenExpiration = expiration;

		var refreshedUser = SaveUser(user);

		cookieManager.SetRefreshTokenCookie(user.RefreshToken, httpContext);

		return refreshedUser;
	}
}
