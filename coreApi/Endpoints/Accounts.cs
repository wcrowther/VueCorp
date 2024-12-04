using coreApi.Helpers;
using coreApi.Logic.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using Microsoft.AspNetCore.Mvc;

namespace coreApi;

public static partial class Endpoints
{
    public static void AccountEndpoints(this WebApplication app)
    {
        var accounts = app.MapGroup("/v1/accounts")
						  //.RequireAuthorization()
                          .WithOpenApi()
						  .WithTags("Accounts");

        accounts.MapGet("/getAllAccounts", (IAccountManager _accountManager) =>
        {
            var accounts = _accountManager.GetAllAccounts();

            return Results.Ok(accounts);
        });

        accounts.MapPost("/getPagedAccounts", (IAccountManager _accountManager, [FromBody] Pager<SearchForAccount> pager) =>
        {
            var accounts = _accountManager.GetPagedAccounts(pager);

            return Results.Ok(accounts);
        });

        accounts.MapGet("/getAccountById/{accountId}", (IAccountManager _accountManager, int accountId) =>
        {
            var acct = _accountManager.GetAccountById(accountId);

            return Results.Ok(acct);
        });

		accounts.MapPost("/saveAccount", (IAccountManager _accountManager, [FromBody] Account account) =>
		{
			var acct = _accountManager.SaveAccount(account);

			return Results.Ok(acct);
		})
		.Validate<Account>(false);
		//.ValidateDataAnnotationsFromBody();
	}
}






// ============================================================================
// NOT WORKING ON /saveAccount replacing ".ValidateDataAnnotations<Account>()"
// ============================================================================
// .AddEndpointFilterFactory((filterFactoryContext, next) =>
// {
// 	var fromBodyType = filterFactoryContext.MethodInfo.GetParameters()
// 						.FirstOrDefault(pi => pi.GetCustomAttributes<FromBodyAttribute>().Any())
// 						.GetType();
// 
// 	if (fromBodyType != null)
// 	{
// 		return async invocationContext =>
// 		{
// 			var response = fromBodyType.DataAnnotationsValidate();
// 
// 			if (!response.IsValid)
// 			{
// 				return Results.Problem(response.Results.FirstOrDefault().ErrorMessage, statusCode: 400);
// 			}
// 			return await next(invocationContext);
// 		};
// 	}
// 	else 
// 	{ 			
// 		return async invocationContext =>
// 		{
// 			return Results.Problem("Endpoints with this Filter must have a FromBody parameter.", statusCode: 400);
// 		};
// 	}
// 	// return invocationContext => next(invocationContext);
// });

