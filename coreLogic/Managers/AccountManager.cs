using Microsoft.Extensions.Options;
using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreApi.Logic.Interfaces;
using Microsoft.AspNetCore.Http;

namespace coreApi.Logic;

public class AccountManager : IAccountManager
{
    private readonly AppSettings _appSettings;
    private readonly IAccountRepo _accountRepo;

    public AccountManager( IOptions<AppSettings> appSettings,
                           IAccountRepo accountRepo)
    {
        _appSettings = appSettings.Value;
        _accountRepo = accountRepo;
    }

    public async Task<List<Account>> GetAllAccounts()
    {
        return await _accountRepo.GetAllAccounts();
    }

    public async Task<Account> GetAccountById(int accountId)
    {
			return await _accountRepo.GetAccountById(accountId);
    }

    public async Task<PagedList<Account,SearchForAccount>> GetPagedAccounts(Pager<SearchForAccount> pager)
    {
        pager ??= new Pager<SearchForAccount>();

        return await _accountRepo.GetPagedAccounts(pager);
    }

	public async Task<Account> SaveAccount(Account account, User user)
	{
		// account.ModifiedBy = user.UserId;
		await _accountRepo.SaveAccount(account);

		return account;
	}
}