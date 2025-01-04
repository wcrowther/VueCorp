using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Helpers;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WildHare.Extensions;

namespace coreApi.Data;

public class AccountRepo : IAccountRepo
{
	private readonly CoreApiDataContext _dataContext;

	public AccountRepo(CoreApiDataContext coreApiDataContext)
	{
		_dataContext = coreApiDataContext;
	}

	public virtual async Task<PagedList<Account,SearchForAccount>> GetPagedAccounts(Pager<SearchForAccount> pager)
	{
		var predicate = BuildPredicate(pager);

		var query = _dataContext.Accounts.Where(predicate);

		pager.TotalCount = await query.CountAsync();
		var listItems	 = await query.OrderBy(p => p.AccountName)
								.Skip(pager.FirstRecordInPage - 1)
								.Take(pager.PageSize)
								.ToListAsync();

		var pagedList = new PagedList<Account,SearchForAccount>
		{
			ListItems   = listItems,
			Pager       = pager
		};

		return pagedList;
	}

	public async Task<List<Account>> GetAllAccounts()
	{
		return await _dataContext.Accounts.ToListAsync();
	}

	public async Task<Account> GetAccountById(int accountId)
	{
		return await _dataContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == accountId);
	}

	public async Task<Account> SaveAccount(Account account)
	{
		_dataContext.Update(account);
		await _dataContext.SaveChangesAsync();

		return account;
	}

	// =======================================================================================

	private static ExpressionStarter<Account> BuildPredicate(Pager<SearchForAccount> pager, bool search = true)
	{
		var trimAndRemoveEmpty = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;

		// 'search' true means start with all, otherwise will start with empty.
		// PredicateBuilder with no parameter will start with an empty list
		// or populate with true to include all records

		var predicate		= search ? PredicateBuilder.New<Account>(true) : PredicateBuilder.New<Account>();  
		string[] filters	= pager.Search.Filter.Split(',', trimAndRemoveEmpty);

		foreach (string filter in filters)
		{
			if (filter.IsNullOrSpace())
				continue;

			if (filter.IsNumeric())
				predicate = predicate.Or(p => p.AccountId == filter.ToInt(0));
			else
				predicate = predicate.Or(AccountNameFilter(filter.ToLower()));
		}

		if (!pager.Search.StateProvinceFilter.IsNullOrSpace())
		{
			predicate = predicate.And(account => account.StateProvince.Equals(pager.Search.StateProvinceFilter));
		}

		if (!pager.Search.PostalCodeFilter.IsNullOrSpace())
		{
			predicate = predicate.And(account => account.PostalCode.StartsWith(pager.Search.PostalCodeFilter));
		}

		return predicate;
	}

	private static Expression<Func<Account, bool>> AccountNameFilter(string f)
	{
		return p => p.AccountName.StartsWith(f);
	}
}



// =================================================================================================================
// Use SeedPacket to generate list
// private List<Account> Accounts => new List<Account>().Seed(127, new Random(43454)).ToList();
