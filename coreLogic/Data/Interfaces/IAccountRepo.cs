using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Data.Interfaces
{
    public interface IAccountRepo
    {
        List<Account> GetAllAccounts();

        Account GetAccountById(int accountId);

		PagedList<Account,SearchForAccount> GetPagedAccounts(Pager<SearchForAccount> pager);

		Account SaveAccount(Account account);
	}
}