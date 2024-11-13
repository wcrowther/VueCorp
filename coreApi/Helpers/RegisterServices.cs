using coreApi.Data;
using coreApi.Data.Interfaces;
using coreApi.Logic;
using coreApi.Logic.Interfaces;
using coreApi.Logic.Managers;
using coreApi.Managers;

namespace coreApi.Helpers
{
    public static class RegisterServices
    {
        public static void AddMyServices(this IServiceCollection services)
        {
			services.AddDbContext<CoreApiDataContext>();

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
