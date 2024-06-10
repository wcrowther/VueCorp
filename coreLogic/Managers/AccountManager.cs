using Microsoft.Extensions.Options;
using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreApi.Logic.Interfaces;

namespace coreApi.Logic;

public class AccountManager : IAccountManager
{
    private readonly AppSettings _appSettings;
    private readonly IAccountRepo _accountRepo;

    public AccountManager( IOptions<AppSettings> appSettings,
                           IAccountRepo accountRepo)
    {
        _appSettings = appSettings.Value;
        _accountRepo =   accountRepo;
    }

    public List<Account> GetAllAccounts()
    {
        return _accountRepo.GetAllAccounts();
    }

    public Account GetAccountById(int accountId)
    {
        return _accountRepo.GetAccountById(accountId);
    }

    public PagedList<Account,SearchForAccount> GetPagedAccounts(Pager<SearchForAccount> pager)
    {
        pager ??= new Pager<SearchForAccount>();

        return _accountRepo.GetPagedAccounts(pager);
    }

	public Account SaveAccount(Account account)
	{
		_accountRepo.SaveAccount(account);

		return account;
	}
}