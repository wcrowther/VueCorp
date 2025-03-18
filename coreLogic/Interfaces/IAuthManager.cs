using coreApi.Models;
using coreLogic.Models;
using coreLogic.Models.Generic;
using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface IAuthManager
{
	Returns<AuthUser> Authenticate(AuthRequest authRequest);

	Returns<AuthUser> Signup(UserToCreate userToCreate, HttpContext httpContext);

	Returns<AuthUser> RefreshAuth(AuthRefreshRequest request, HttpContext httpContext);
}