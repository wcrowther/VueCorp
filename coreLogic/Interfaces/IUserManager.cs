using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Logic.Interfaces;

public interface IUserManager
{
    IEnumerable<User> GetAllUsers();

	User GetUserByUsername(string username);

	User GetUserById(int id);

	User CreateNewUser(AuthSignup model, string passwordHash);

	PagedList<User> GetPagedUsers(Pager pager);

	User SaveUser(User user);
}
