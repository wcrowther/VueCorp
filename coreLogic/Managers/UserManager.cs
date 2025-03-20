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

	public PagedList<User> GetPagedUsers(Pager pager)
	{
		pager ??= new Pager();

		return userRepo.GetPagedUsers(pager);
	}

	public User SaveUser(User user)
	{
		return userRepo.SaveUser(user);
	}

	public User CreateUser(UserToCreate userToCreate, HttpContext httpContext)
	{
		tokenManager.CreateNewRefreshTokenForUser(userToCreate);

		var createdUser = userRepo.CreateUser(userToCreate, bCrypt.HashPassword(userToCreate.Password));

		cookieManager.SetRefreshTokenCookie(createdUser.RefreshToken, httpContext);

		return createdUser;
	}

	public User UpdateUserRefreshToken(User user, HttpContext httpContext)
	{
		tokenManager.CreateNewRefreshTokenForUser(user);

		var refreshedUser = SaveUser(user);

		cookieManager.SetRefreshTokenCookie(user.RefreshToken, httpContext);

		return refreshedUser;
	}
}
