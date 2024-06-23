using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Logic.Interfaces
{
    public interface IAuthManager
    {
		AuthResponse Authenticate(AuthRequest model);

		Result<AuthResponse> Signup(UserCreate model);
	}
}