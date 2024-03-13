using coreApi.Data;
using coreApi.Data.Interfaces;
using coreApi.Logic;
using coreApi.Logic.Interfaces;
using coreApi.Logic.Managers;

namespace coreApi.Managers
{
    public static class AddServices
    {
        public static void AddMyServices(this IServiceCollection services)
        {
			services.AddDbContext<coreApiDataContext>();

			// Logic Services
			services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IUserManager,    UserManager>();
            services.AddScoped<IAuthManager,    AuthManager>();

            // Data Services
            services.AddScoped<IAccountRepo,    AccountRepo>();
            services.AddScoped<IUserRepo,       UserRepo>();
        }
    }
}
