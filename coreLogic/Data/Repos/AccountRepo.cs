using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Helpers;
using LinqKit;
using System.Linq.Expressions;
using WildHare.Extensions;

namespace coreApi.Data
{
	public class AccountRepo : IAccountRepo
    {
		private readonly coreApiDataContext _dataContext;

		public AccountRepo(coreApiDataContext coreApiDataContext)
		{
			_dataContext = coreApiDataContext;
		}

		public virtual PagedList<Account> GetPagedAccounts(Pager pager)
		{
			var predicate = BuildPredicate(pager);

			var query = _dataContext.Accounts.Where(predicate);

			pager.TotalCount = query.Count();
			var listItems	 = query.OrderBy(p => p.AccountName)
									.Skip(pager.FirstRecordInPage - 1)
									.Take(pager.PageSize)
									.ToList();

			var pagedList = new PagedList<Account>
			{
				ListItems   = listItems,
				Pager       = pager
			};

			return pagedList;
		}

		public List<Account> GetAllAccounts()
		{
			return _dataContext.Accounts.ToList();
		}

		public Account GetAccountById(int accountId)
		{
			return _dataContext.Accounts.FirstOrDefault(x => x.AccountId == accountId);
		}

		public Account SaveAccount(Account account)
		{
			_dataContext.Update(account);
			_dataContext.SaveChanges();

			return account;
		}

		// =======================================================================================

		private static ExpressionStarter<Account> BuildPredicate(Pager pager, bool search = true)
		{
			var options = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;

			// 'search' true means start with all, otherwise will start with empty.
			// PredicateBuilder with no parameter will start with an empty list
			// or populate with true to include all records

			var predicate		= search ? PredicateBuilder.New<Account>(true) : PredicateBuilder.New<Account>();  
			string[] filters	= pager.Search.Filter.Split(',', options);

			foreach (string filter in filters)
			{
				if (filter.IsNullOrSpace())
					continue;

				if (filter.IsNumeric())
					predicate = predicate.Or(p => p.AccountId == filter.ToInt(0));
				else
					predicate = predicate.Or(AccountNameFilter(filter.ToLower()));
			}

			return predicate;
		}

		private static Expression<Func<Account, bool>> AccountNameFilter(string f)
		{
			return p => p.AccountName.StartsWith(f);
		}
	}
}



// =================================================================================================================
// Use SeedPacket to generate list
// private List<Account> Accounts => new List<Account>().Seed(127, new Random(43454)).ToList();
