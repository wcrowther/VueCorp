using coreApi.Hubs;

namespace coreApi.Helpers;

public static class SignalRHubsHelper
{
	const string hubRoot = "/v1";
	
	public static void RegisterRealtimeHubs(this WebApplication app)
    {
		app.MapHub<ChatHub>($"{hubRoot}/chathub");
	}
}
