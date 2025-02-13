using coreApi.Models;

namespace coreLogic.Interfaces;

public interface ITokenManager
{
	string GenerateJwt(User user);

	(string token, DateTime expiration) GenerateRefreshTokenAndExpiration();
}