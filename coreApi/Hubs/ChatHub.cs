using Microsoft.AspNetCore.SignalR;

namespace coreApi.Hubs;

public class ChatHub : Hub
{
	public async Task SendMessage(string userName, int userId, string message)
	{
		await Clients.All.SendAsync("ReceiveMessage", userName, userId, message);
	}
}