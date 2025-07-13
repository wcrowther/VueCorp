using Microsoft.EntityFrameworkCore;
using coreApi.Models;
using coreLogic.Interfaces;
using coreLogic.Managers;
using Microsoft.AspNetCore.Http;
using System;

namespace coreApi.Data;

public class CoreApiDataContext(DbContextOptions<CoreApiDataContext> options,
								IUserClaimsManager currentUserManager) 
: DbContext(options)
{
	public override int SaveChanges()
	{
		ApplyAuditInfo();
		return base.SaveChanges();
	}

	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		ApplyAuditInfo();
		return await base.SaveChangesAsync(cancellationToken);
	}

	public DbSet<Account> Accounts { get; set; }

	public DbSet<User> Users { get; set; }

	public DbSet<Message> Messages { get; set; }

	// ============================================================================================================

	private void ApplyAuditInfo()
	{
		var now		= DateTime.Now;
		var userId	= currentUserManager.GetCurrentUserId(); 

		if(userId == null)
			return;

		foreach (var entry in ChangeTracker.Entries<IAuditable>())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Entity.DateCreated	= now;
				entry.Entity.CreatorId		= userId.Value;
			}

			if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
			{
				entry.Entity.DateModified   = now;
				entry.Entity.ModifierId     = userId.Value;
			}
		}
	}
}






// ALTERNATE WAY TO DO PATH
// var folder	= Environment.SpecialFolder.LocalApplicationData;
// var path		= Environment.GetFolderPath(folder);
// DbPath		= Path.Join(path, "coreApiData.db");