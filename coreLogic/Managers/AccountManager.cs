using Microsoft.Extensions.Options;
using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreApi.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using coreLogic.Data.Interfaces;
using SQLitePCL;

namespace coreApi.Logic;

public class AccountManager (	IAccountRepo accountRepo,
								IUserRepo userRepo
							)
: IAccountManager
{
    public async Task<List<Account>> GetAllAccounts()
    {
        return await accountRepo.GetAllAccounts();
    }

    public async Task<Account> GetAccountById(int accountId)
    {
		var account = await accountRepo.GetAccountById(accountId);

		PopulateAccountAuditableNames(ref account);

		return account;
	}

    public async Task<PagedList<Account,SearchForAccount>> GetPagedAccounts(Pager<SearchForAccount> pager)
    {
        pager ??= new Pager<SearchForAccount>();

        return await accountRepo.GetPagedAccounts(pager);
    }

	public async Task<Account> SaveAccount(Account account)
	{
		var acct = await accountRepo.SaveAccount(account);

		PopulateAccountAuditableNames(ref acct);

		return acct;
	}

	// ==========================================================================================

	private void PopulateAccountAuditableNames(ref Account account)
	{
		if (account is null) return;

		account.CreatorName     = userRepo.GetUsernameById(account.CreatorId);
		account.ModifierName    = userRepo.GetUsernameById(account.ModifierId);
	}
}