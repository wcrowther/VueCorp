using Microsoft.Extensions.Options;
using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreApi.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using coreLogic.Data.Interfaces;
using SQLitePCL;
using coreLogic.Interfaces;

namespace coreApi.Logic;

public class MessageManager(	IMessageRepo messageRepo,
								IUserRepo userRepo
							)
: IMessageManager
{
    public async Task<List<Message>> GetAllMessages()
    {
        return await messageRepo.GetAllMessages();
    }

	public async Task<Message> SaveMessage(Message message)
	{
		var savedMessage = await messageRepo.SaveMessage(message);

		PopulateMessageAuditableNames(ref savedMessage);

		return savedMessage;
	}

	// ==========================================================================================

	private void PopulateMessageAuditableNames(ref Message message)
	{
		if (message is null) return;

		message.CreatorName  = userRepo.GetUsernameById(message.CreatorId);

		if (message.CreatorId == message.ModifierId)
			message.ModifierName = message.CreatorName;
		else
			message.ModifierName = userRepo.GetUsernameById(message.ModifierId);
	}
}
