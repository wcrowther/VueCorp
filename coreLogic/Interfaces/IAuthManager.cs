using coreApi.Models;
using coreLogic.Models.Generic;

namespace coreLogic.Interfaces
{
	public interface IAuthManager
	{
		AuthResponse Authenticate(AuthRequest model);

		Returns<AuthResponse> Signup(UserToCreate userToCreate);
	}
}