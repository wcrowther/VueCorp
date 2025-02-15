using coreApi.Models;
using coreLogic.Models;
using coreLogic.Models.Generic;

using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface IAuthManager
{
	AuthUser Authenticate(AuthRequest model);

	Returns<AuthUser> Signup(UserToCreate userToCreate);

	Returns<AuthUser> RefreshAuth(AuthRefreshRequest request, HttpContext httpContext);
}