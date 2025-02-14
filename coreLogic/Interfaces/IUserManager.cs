﻿using coreApi.Models;
using coreApi.Models.Generic;
using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface IUserManager
{
	IEnumerable<User> GetAllUsers();

	User GetUserByUsername(string username);

	User GetUserById(int id);

	User CreateUser(UserToCreate model, string passwordHash);

	PagedList<User> GetPagedUsers(Pager pager);

	User SaveUser(User user);

	User CreateUser(UserToCreate userToCreate);

	User UpdateUserRefreshToken(User user, HttpContext httpContext);
}
