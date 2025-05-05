using coreApi.Data;
using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Data.Interfaces;
using coreLogic.Helpers;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WildHare.Extensions;

namespace coreLogic.Data.Repos;

public class UserRepo(CoreApiDataContext coreApiDataContext)
: IUserRepo, IDisposable
{
	private bool _disposed;

	public IEnumerable<User> GetAllUsers()
	{
		return coreApiDataContext.Users;
	}

	public User GetUserByUserName(string username)
	{
		return coreApiDataContext.Users.FirstOrDefault(x => x.UserName == username);
	}

	public User GetUserById(int userId)
	{
		return coreApiDataContext.Users.FirstOrDefault(x => x.UserId == userId);
	}

	public string GetUsernameById(int userId)
	{
		return GetUserById(userId)?.UserName ?? "Unknown";
	}

	public User CreateUser(UserToCreate model, string passwordHash)
	{
		var newUser = new User
		{
			UserName                = model.UserName,
			FirstName               = model.FirstName,
			LastName                = model.LastName,
			UserEmail               = model.UserEmail,
			RefreshToken            = model.RefreshToken,
			RefreshTokenExpiration  = model.RefreshTokenExpiration,
			Role                    = model.Role,
			PasswordHash            = passwordHash,
		};

		coreApiDataContext.Add(newUser);
		coreApiDataContext.SaveChanges();

		return newUser;
	}

	public PagedList<User> GetPagedUsers(Pager pager)
	{
		var predicate = BuildPredicate(pager);

		var query = coreApiDataContext.Users.Where(predicate);

		pager.TotalCount = query.Count();
		var listItems = query.OrderBy(p => p.LastName ?? "")
								.Skip(pager.FirstRecordInPage - 1)
								.Take(pager.PageSize)
								.ToList();

		var pagedList = new PagedList<User>
		{
			ListItems   = listItems,
			Pager       = pager
		};

		return pagedList;
	}

	public User SaveUser(User user)
	{
		// Password cannot be changed by this call so get the original PasswordHash and set it

		var passwordHash = coreApiDataContext.Users.AsNoTracking()
									   .FirstOrDefault(u => u.UserId == user.UserId)
									   ?.PasswordHash;
		if (passwordHash is not null)
			user.PasswordHash = passwordHash;

		coreApiDataContext.Update(user);
		coreApiDataContext.SaveChanges();

		return user;
	}

	// =======================================================================================

	private static ExpressionStarter<User> BuildPredicate(Pager pager, bool search = true)
	{
		var options = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries;

		// 'search' true means start with all, otherwise will start with empty.
		// PredicateBuilder with no parameter will start with an empty list
		// or populate with true to include all records

		var predicate = search ? PredicateBuilder.New<User>(true) : PredicateBuilder.New<User>();
		string[] filters = pager.Search.Filter.Split(',', options);

		foreach (string filter in filters)
		{
			if (filter.IsNullOrSpace())
				continue;

			if (filter.IsNumeric())
			{
				predicate = predicate.Or(p => p.UserId == filter.ToInt(0));
			}
			else
			{
				predicate = predicate.Or(UserNameFilter(filter));
				predicate = predicate.Or(p => p.FirstName.StartsWith(filter));
				predicate = predicate.Or(p => p.LastName.StartsWith(filter));
				predicate = predicate.Or(p => p.UserEmail.StartsWith(filter));
			}
		}

		return predicate;
	}

	// Example expression function
	private static Expression<Func<User, bool>> UserNameFilter(string f)
	{
		return p => p.UserName.StartsWith(f);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_disposed)
		{
			if (disposing)
				coreApiDataContext.Dispose();

			_disposed = true;
		}
	}
	public void Dispose()
	{
		Dispose(true);
		GC.SuppressFinalize(this);
	}
}



// ====================================================================================================
//	Example for adding missing data
// ====================================================================================================
//	public void GenerateRefreshTokensForWhereEmpty()
//	{
//		var allUsers = _dataContext.Users.Where(w => string.IsNullOrEmpty(w.RefreshToken));

//		foreach (var user in allUsers)
//		{
//			var (token, expiration) = _tokenManager.GenerateRefreshTokenAndExpiration();
//			user.RefreshToken = token;
//			user.RefreshTokenExpiration = expiration;

//			_dataContext.Update(user);
//		}
//		_dataContext.SaveChanges();
//	}
