using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Data.Interfaces;

public interface IAccountRepo
{
	Task<List<Account>> GetAllAccounts();

	Task<Account> GetAccountById(int accountId);

	Task<PagedList<Account, SearchForAccount>> GetPagedAccounts(Pager<SearchForAccount> pager);

	Task<Account> SaveAccount(Account account);
}