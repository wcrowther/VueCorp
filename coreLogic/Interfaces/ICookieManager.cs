using Microsoft.AspNetCore.Http;

namespace coreLogic.Interfaces;

public interface ICookieManager
{
	void SetRefreshTokenCookie(string refreshToken);
}