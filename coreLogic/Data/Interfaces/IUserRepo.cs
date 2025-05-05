using coreApi.Models;
using coreApi.Models.Generic;

namespace coreLogic.Data.Interfaces;

public interface IUserRepo
{
	IEnumerable<User> GetAllUsers();

	User GetUserByUserName(string username);

	User GetUserById(int userId);

	string GetUsernameById(int userId);

	User CreateUser(UserToCreate model, string passwordHash);

	PagedList<User> GetPagedUsers(Pager pager);

	User SaveUser(User user);
}