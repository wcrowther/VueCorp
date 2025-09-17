using coreApi.Models;
using coreApi.Models.Generic;
using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface IUserManager
{	
	User GetUserByUsername(string username);

	User GetUserById(int id);
	
	IEnumerable<User> GetAllUsers();

	PagedList<User, SearchForUser> GetPagedUsers(Pager<SearchForUser> pager);

	User SaveUser(User user);

	User CreateUser(UserToCreate userToCreate);

	User UpdateUserRefreshToken(User user);
}
