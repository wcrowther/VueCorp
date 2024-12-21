using coreApi.Models;
using coreLogic.Models.Generic;

namespace coreApi.Logic.Interfaces
{
	public interface IAuthManager
    {
		AuthResponse Authenticate(AuthRequest model);

		Returns<AuthResponse> Signup(UserCreate model);
	}
}