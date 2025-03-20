using coreApi.Models;
using coreLogic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace coreLogic.Managers;

public class CookieManager(	AppSettings appSettings) 
: ICookieManager
{
	public void SetRefreshTokenCookie(string refreshToken, HttpContext httpContext)
	{
		httpContext.Response.Cookies.Append("refreshToken", refreshToken, new CookieOptions
		{
			HttpOnly	= true,						// Prevent access from JavaScript
			Secure		= true,						// Require HTTPS
			SameSite	= SameSiteMode.None,		// Prevent CSRF attacks
			Expires		= DateTime.Now.AddDays(appSettings.RefreshTokenExpirationDays)
		});
	}
}
