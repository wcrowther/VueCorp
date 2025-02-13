using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Data.Interfaces;
using coreLogic.Interfaces;
using bCrypt = BCrypt.Net.BCrypt;

namespace coreLogic.Managers;

public class UserManager(IUserRepo userRepo,
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

	public User CreateUser(UserToCreate userToCreate)
	{
		var (token, expiration) = tokenManager.GenerateRefreshTokenAndExpiration();

		userToCreate.RefreshToken           = token;
		userToCreate.RefreshTokenExpiration = expiration;

		string passwordHash = bCrypt.HashPassword(userToCreate.Password);

		return userRepo.CreateUser(userToCreate, passwordHash);
	}

	public User UpdateUserRefreshToken(User user)
	{
		var (token, expiration) = tokenManager.GenerateRefreshTokenAndExpiration();

		user.RefreshToken           = token;
		user.RefreshTokenExpiration = expiration;

		return SaveUser(user);
	}
}
