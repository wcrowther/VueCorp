using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Data.Interfaces;

public interface IUserRepo
{
    IEnumerable<User> GetAllUsers();

	User GetUserByUserName(string username);

	User GetUserById(int userId);

	User CreateUser(UserCreate model, string passwordHash);

	PagedList<User> GetPagedUsers(Pager pager);

	User SaveUser(User user);
}