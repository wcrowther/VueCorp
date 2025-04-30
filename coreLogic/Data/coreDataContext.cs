using Microsoft.EntityFrameworkCore;
using coreApi.Models;
using coreLogic.Interfaces;
using coreLogic.Managers;
using Microsoft.AspNetCore.Http;
using System;

namespace coreApi.Data;

public class CoreApiDataContext(DbContextOptions<CoreApiDataContext> options) // 
: DbContext(options)
{
	//private readonly IAuthManager _authManager;
	//private readonly HttpContext _httpContext;

	//public CoreApiDataContext(	DbContextOptions<CoreApiDataContext> options)
								//IAuthManager authManager,
								//HttpContext httpContext
								//)
	//: base(options)
	//{
		//_authManager=authManager;
		//_httpContext=httpContext;
	//}

	// public override int SaveChanges()
	// {
	// 	ApplyAuditInfo();
	// 	return base.SaveChanges();
	// }

	// public string DbPath { get; }

	public DbSet<Account> Accounts { get; set; }

	public DbSet<User> Users { get; set; }

	// ============================================================================================================

	// private void ApplyAuditInfo()
	// {
	// 	var now		= DateTime.Now;
	// 	var userId	= _authManager.GetCurrentUser(_httpContext).Data.UserId;
	// 
	// 	foreach (var entry in ChangeTracker.Entries<IAuditable>())
	// 	{
	// 		if (entry.State == EntityState.Added)
	// 		{
	// 			entry.Entity.DateCreated	= now;
	// 			entry.Entity.CreatorId		= userId;
	// 		}
	// 
	// 		if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
	// 		{
	// 			entry.Entity.DateModified	= now;
	// 			entry.Entity.ModifierId		= userId;
	// 		}
	// 	}
	// }
	// public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	// {
	// 	ApplyAuditInfo();
	// 	return await base.SaveChangesAsync(cancellationToken);
	// }

	// ============================================================================================================
	// The following configures EF to create a Sqlite database file in the special "local" folder for your platform.
	// protected override void OnConfiguring(DbContextOptionsBuilder options)
	// {
	// 	options.UseSqlite($"Data Source=coreApiData.db");
	// }
}






// ALTERNATE WAY TO DO PATH
// var folder	= Environment.SpecialFolder.LocalApplicationData;
// var path		= Environment.GetFolderPath(folder);
// DbPath		= Path.Join(path, "coreApiData.db");