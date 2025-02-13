using coreApi.Models;

namespace coreLogic.Adapters;

public static partial class Adapter
{
	public static AuthResponse ToAuthResponse(this User user, string token)
	{
		if (user == null)
			return null;

		var authResponse = new AuthResponse(user, token);

		return authResponse;
	}
}