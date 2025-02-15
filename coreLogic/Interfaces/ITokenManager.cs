using coreApi.Models;

namespace coreLogic.Interfaces;

public interface ITokenManager
{
	(string token, DateTime expiration) GenerateJwtToken(User user);

	(string token, DateTime expiration) GenerateRefreshTokenAndExpiration();
}