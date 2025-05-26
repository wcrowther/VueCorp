using coreApi.Models;
using coreLogic.Models;
using coreLogic.Models.Generic;
using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface IAuthManager
{
	(User, Result) GetCurrentUser();

	(AuthUser,Result) Authenticate(AuthRequest authRequest);

	(AuthUser, Result) Signup(UserToCreate userToCreate);

	(AuthUser, Result) RefreshAuth(AuthRefreshRequest request);
}