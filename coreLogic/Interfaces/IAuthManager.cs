using coreApi.Models;
using coreLogic.Models;
using coreLogic.Models.Generic;
using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface IAuthManager
{
	(User user, Errors errors) GetCurrentUser(HttpContext httpContext);

	Returns<AuthUser> Authenticate(AuthRequest authRequest, HttpContext httpContext);

	Returns<AuthUser> Signup(UserToCreate userToCreate, HttpContext httpContext);

	Returns<AuthUser> RefreshAuth(AuthRefreshRequest request, HttpContext httpContext);
}