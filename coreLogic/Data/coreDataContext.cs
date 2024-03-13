using Microsoft.EntityFrameworkCore;
using coreApi.Models;

namespace coreApi.Data;

public class coreApiDataContext : DbContext
{
	public coreApiDataContext() 
	{
		DbPath      = "coreApiData.db";
	}

	public string DbPath { get; }

	public DbSet<Account> Accounts { get; set; }

	public DbSet<User> Users { get; set; }

	// The following configures EF to create a Sqlite database file in the special "local" folder for your platform.
	protected override void OnConfiguring(DbContextOptionsBuilder options)
	{
		options.UseSqlite($"Data Source={DbPath}");
	}
}

// ALTERNATE WAY TO DO PATH
// var folder	= Environment.SpecialFolder.LocalApplicationData;
// var path		= Environment.GetFolderPath(folder);
// DbPath		= Path.Join(path, "coreApiData.db");