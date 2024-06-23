using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Logic.Interfaces;

public interface IUserManager
{
    IEnumerable<User> GetAllUsers();

	User GetUserByUsername(string username);

	User GetUserById(int id);

	User CreateUser(UserCreate model, string passwordHash);

	PagedList<User> GetPagedUsers(Pager pager);

	User SaveUser(User user);

	User CreateUser(UserCreate newUser);
}
