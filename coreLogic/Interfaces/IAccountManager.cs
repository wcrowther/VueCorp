using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Logic.Interfaces
{
    public interface IAccountManager
    {
        List<Account> GetAllAccounts();

        public Account GetAccountById(int id);

        PagedList<Account> GetPagedAccounts(Pager pager);

		Account SaveAccount(Account account);

	}
}