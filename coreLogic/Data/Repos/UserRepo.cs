using coreApi.Models;
using coreApi.Data.Interfaces;
using coreApi.Models.Generic;
using System.Security.Principal;
using LinqKit;
using coreLogic.Helpers;
using System.Linq.Expressions;
using WildHare.Extensions;
using Microsoft.EntityFrameworkCore;

namespace coreApi.Data
{
    public class UserRepo : IUserRepo
    {
		private readonly coreApiDataContext _dataContext;

		public UserRepo()
		{
			_dataContext = new coreApiDataContext();
		}

		public IEnumerable<User> GetAllUsers()
        {
			return _dataContext.Users;
		}

		public User GetUserByUserName(string username)
		{
			return _dataContext.Users.FirstOrDefault(x => x.UserName == username);
		}

		public User GetUserById(int userId)
        {
            return _dataContext.Users.FirstOrDefault(x => x.UserId == userId);
		}

		public User CreateNewUser(AuthSignup model, string passwordHash)
		{
			var newUser = new User
			{
				UserName		= model.UserName,
				FirstName		= model.FirstName,
				LastName        = model.LastName,
				UserEmail       = model.UserEmail,
				PasswordHash    = passwordHash,
				Roles			= "User" 
			};
			
			_dataContext.Add(newUser);
			_dataContext.SaveChanges();

			return newUser;	
		}

		public PagedList<User> GetPagedUsers(Pager pager) 
		{
			var predicate = BuildPredicate(pager);

			var query = _dataContext.Users.Where(predicate);

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
			
			var passwordHash = _dataContext.Users.AsNoTracking()
										   .FirstOrDefault(u => u.UserId == user.UserId)
										   ?.PasswordHash;
			if (passwordHash is not null) 
				user.PasswordHash = passwordHash;

			_dataContext.Update(user);
			_dataContext.SaveChanges();

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
	}
}


// =================================================================================================================

// static string _hash = BCrypt.Net.BCrypt.HashPassword("Test123!");

// Users hardcoded for simplicity, store in a db with hashed passwords in production applications
// private readonly List<User> _users = new()
// 		{
// 			new User {  UserId = 1, FirstName = "Test", LastName = "User",
// 						Username = "test", PasswordHash = _hash,  Roles = "User" },
// 
// 			new User {  UserId = 2, FirstName = "Will", LastName = "Crowther",
// 						Username = "wcrowther22", PasswordHash = _hash , Roles = "Admin"}
// 		};
