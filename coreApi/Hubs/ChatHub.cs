﻿using coreApi.Models;
using Microsoft.AspNetCore.SignalR;

namespace coreApi.Hubs;

public class ChatHub : Hub
{
	public async Task SendMessage(Message message)
	{
		await Clients.All.SendAsync("ReceiveMessage", message);
	}
}