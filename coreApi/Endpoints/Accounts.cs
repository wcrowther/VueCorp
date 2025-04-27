using coreApi.Helpers;
using coreApi.Logic.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Helpers;
using coreLogic.Interfaces;
using coreLogic.Models.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace coreApi;

public static partial class Endpoints
{
    public static void AccountEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/v1/accounts")
							.RequireAuthorization()
							.WithOpenApi()
							.WithTags("Accounts");

        endpoints.MapGet("/getAllAccounts", (	IAccountManager _accountManager) =>
        {
            var accounts = _accountManager.GetAllAccounts();

            return Results.Ok(accounts);
        });

        endpoints.MapPost("/getPagedAccounts", (	IAccountManager _accountManager, 
													[FromBody] Pager<SearchForAccount> pager) =>
        {
            var accounts = _accountManager.GetPagedAccounts(pager);

            return Results.Ok(accounts);
        });

        endpoints.MapGet("/getAccountById/{accountId}", (	IAccountManager _accountManager, 
															int accountId) =>
        {
            var acct = _accountManager.GetAccountById(accountId);

            return Results.Ok(acct);
        });

		endpoints.MapPost("/saveAccount", (		IAccountManager _accountManager,
												IAuthManager _authManager,
												HttpContext httpContext,
												[FromBody] Account account) =>
		{
			var response = _authManager.GetCurrentUser(httpContext);

			if (response.IsFailure())
				return Results.BadRequest(response.errors.Message);

			var acct = _accountManager.SaveAccount(account, response.user);

			return  acct.Map(
				acct => Results.Ok(acct), 
				errors => Results.BadRequest(errors));
		})
		.Validate<Account>(false);
	}
}

