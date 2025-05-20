using coreApi.Data;
using coreApi.Data.Interfaces;
using coreApi.Logic;
using coreApi.Logic.Interfaces;
using coreLogic.Data.Interfaces;
using coreLogic.Data.Repos;
using coreLogic.Interfaces;
using coreLogic.Managers;

namespace coreApi.Helpers
{
	public static class RegisterServices
    {
        public static void AddMyServices(this IServiceCollection services)
        {
			services.AddDbContext<CoreApiDataContext>();

			// Logic Services
			services.AddScoped<IAccountManager,		AccountManager>();
            services.AddScoped<IUserManager,		UserManager>();
			services.AddScoped<IAuthManager,		AuthManager>();
			services.AddScoped<IContentManager,		ContentManager>();
			services.AddScoped<ITokenManager,		TokenManager>();
			services.AddScoped<ICookieManager,		CookieManager>();
			services.AddScoped<IUserClaimsManager,	UserClaimsManager>();

			// Data Services
			services.AddScoped<IAccountRepo,		AccountRepo>();
			services.AddScoped<IUserRepo,			UserRepo>();
			services.AddScoped<IContentRepo,		ContentRepo>();
		}
	}
}
