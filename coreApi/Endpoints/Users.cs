using coreApi.Helpers;
using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace coreApi;

public static partial class Endpoints
{
    public static void UsersEndpoints(this WebApplication app)
    {
        var users = app.MapGroup("/v1/users")
                       .RequireAuthorization("Admin")
					   .WithOpenApi()
					   .WithTags("Users");


		// getAllUsers
		users.MapGet("/getAllUsers", (IUserManager userManager) =>
        {
            var allUsers = userManager.GetAllUsers();

            return allUsers;
        });

		// getPagedUsers
		users.MapPost("/getPagedUsers", (	IUserManager userManager, 
											[FromBody] Pager pager) =>
		{
			var pagedList = userManager.GetPagedUsers(pager);

			return Results.Ok(pagedList);
		});

		// getUserById
		users.MapGet("/getUserById/{userId}", (		IUserManager userManager, 
													int userId) =>
		{
			var user = userManager.GetUserById(userId);

			return Results.Ok(user);
		});

		// saveUser
		users.MapPost("/saveUser", (	IUserManager userManager, 
										[FromBody] User user) =>
		{
			var savedUser = userManager.SaveUser(user);

			return Results.Ok(savedUser);
		})
		.Validate<User>(false)
		.RequireAuthorization("Admin");

		// createUser
		users.MapPost("/createUser", (	IUserManager _userManager,
										[FromBody] UserToCreate userToCreate,
										HttpContext httpContext) =>
		{
			var createdUser = _userManager.CreateUser(userToCreate, httpContext);

			return Results.Ok(createdUser);
		})
		.Validate<UserToCreate>();
	}
}

