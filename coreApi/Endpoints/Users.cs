﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using coreApi.Models;
using coreApi.Logic.Interfaces;
using coreApi.Models.Generic;
using coreApi.Helpers;

namespace coreApi.Endpoints;

public static partial class Endpoints
{
    public static void UsersEndpoints(this WebApplication app)
    {
        var users = app.MapGroup("/v1/users")
                      .RequireAuthorization("Admin")
					  .WithOpenApi()
					  .WithTags("Users");

		users.MapGet("/getAllUsers", (IUserManager _userManager) =>
        {
            var users = _userManager.GetAllUsers();

            return users;
        });

		users.MapPost("/getPagedUsers", (IUserManager _userManager, [FromBody] Pager pager) =>
		{
			var accounts = _userManager.GetPagedUsers(pager);

			return Results.Ok(accounts);
		});

		users.MapGet("/getUserById/{userId}", (IUserManager _userManager, int userId) =>
		{
			var acct = _userManager.GetUserById(userId);

			return Results.Ok(acct);
		});

		users.MapPost("/saveUser", (IUserManager _userManager, [FromBody] User user) =>
		{
			var acct = _userManager.SaveUser(user);

			return Results.Ok(acct);
		})
		.Validate<User>(false);
	}
}

