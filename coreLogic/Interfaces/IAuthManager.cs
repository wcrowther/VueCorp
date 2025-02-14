using coreApi.Models;
using coreLogic.Models;
using coreLogic.Models.Generic;

using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface IAuthManager
{
	AuthResponse Authenticate(AuthRequest model);

	Returns<AuthResponse> Signup(UserToCreate userToCreate);

	Returns<AuthResponse> RefreshAuth(AuthRefreshRequest request, HttpContext httpContext);
}