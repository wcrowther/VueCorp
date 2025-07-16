﻿using coreApi.Hubs;
using coreApi.Models;
using Microsoft.AspNetCore.SignalR;

namespace coreApi.Helpers;

public static class SignalRHubsHelper
{
	const string hubRoot = "/v1";
	
	/// <summary>Takes incoming call and sends to all in the hub</summary>
	public static void RegisterRealtimeHubs(this WebApplication app)
    {
		app.MapHub<ChatHub>($"{hubRoot}/chathub");
	}

	/// <summary>Send message from the application</summary>
	public static async void SendMessageFromServer(this IHubContext<ChatHub> hubContext, Message message)
	{
		await hubContext.Clients.All.SendAsync("ReceiveMessage", message);
	}

	/// <summary>push out the current server max MessageId</summary>
	public static async void SendMaxMessageId(this IHubContext<ChatHub> hubContext, int maxMessageId)
	{
		await hubContext.Clients.All.SendAsync("ReceiveMaxMessageId", maxMessageId);
	}
}
