using coreApi.Helpers;
using coreApi.Logic.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Interfaces;
using coreLogic.Models.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace coreApi;

public static partial class Endpoints
{
    public static void MessageEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/v1/messages")
							.RequireAuthorization()
							.WithOpenApi()
							.WithTags("Messages");

        endpoints.MapGet("/getAllMessages", ( IMessageManager _messageManager) =>
        {
            var messages = _messageManager.GetAllMessages();

            return Results.Ok(messages);
        });

		endpoints.MapPost("/saveMessage", (	IMessageManager _messageManager,
											[FromBody] Message message) =>
		{
			var savedMessage = _messageManager.SaveMessage(message);

			return Results.Ok(message);
		})
		.Validate<Message>(false);
	}
}

