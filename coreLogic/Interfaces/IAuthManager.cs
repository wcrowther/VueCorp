using coreApi.Models;
using System.IdentityModel.Tokens.Jwt;

namespace coreApi.Logic.Interfaces
{
    public interface IAuthManager
    {
		AuthResponse Authenticate(AuthRequest model);

		AuthResponse Signup(AuthSignup model);
	}
}