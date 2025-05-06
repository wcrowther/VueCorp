using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Data.Interfaces;
using coreLogic.Data.Repos;
using coreLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using bCrypt = BCrypt.Net.BCrypt;

namespace coreLogic.Managers;

public class UserManager(	IUserRepo userRepo,
							ICookieManager cookieManager,
							ITokenManager tokenManager
						)
: IUserManager
{
	public User GetUserByUsername(string username)
	{
		var user = userRepo.GetUserByUserName(username);

		PopulateAuditableNames(ref user);

		return user;
	}

	public User GetUserById(int id)
	{
		var user = userRepo.GetUserById(id);

		PopulateAuditableNames(ref user);

		return user;
	}

	public IEnumerable<User> GetAllUsers()
	{
		return userRepo.GetAllUsers();
	}

	public PagedList<User> GetPagedUsers(Pager pager)
	{
		pager ??= new Pager();

		return userRepo.GetPagedUsers(pager);
	}

	public User SaveUser(User user)
	{
		var usr = userRepo.SaveUser(user);

		PopulateAuditableNames(ref usr);

		return usr;
	}

	public User CreateUser(UserToCreate userToCreate)
	{
		tokenManager.CreateNewRefreshTokenForUser(userToCreate);

		var createdUser = userRepo.CreateUser(userToCreate, bCrypt.HashPassword(userToCreate.Password));

		cookieManager.SetRefreshTokenCookie(createdUser.RefreshToken);

		return createdUser;
	}

	public User UpdateUserRefreshToken(User user)
	{
		tokenManager.CreateNewRefreshTokenForUser(user);

		var refreshedUser = SaveUser(user);

		cookieManager.SetRefreshTokenCookie(user.RefreshToken);

		return refreshedUser;
	}

	// ==========================================================================================

	private void PopulateAuditableNames(ref User user)
	{
		if (user is null) return;

		user.CreatorName     = userRepo.GetUsernameById(user.CreatorId);
		user.ModifierName    = userRepo.GetUsernameById(user.ModifierId);
	}
}
