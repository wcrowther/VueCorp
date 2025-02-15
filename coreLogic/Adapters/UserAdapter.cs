﻿using coreApi.Models;

namespace coreLogic.Adapters;

public static partial class Adapter
{
	public static AuthUser ToAuthResponse(this User user, string token, DateTime expiration)
	{
		if (user == null)
			return null;

		var authResponse = new AuthUser(user, token, expiration);

		return authResponse;
	}
}