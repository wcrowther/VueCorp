using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Models.Generic;

namespace coreApi.Logic.Interfaces
{
    public interface IAccountManager
    {
        Task<List<Account>> GetAllAccounts();

        Task<Account> GetAccountById(int id);

		Task<PagedList<Account,SearchForAccount>> GetPagedAccounts(Pager<SearchForAccount> pager);

		Task<(Account,Errors)> SaveAccount(Account account, User user);
	}
}