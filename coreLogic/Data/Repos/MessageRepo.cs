using coreApi.Data.Interfaces;
using coreApi.Models;
using coreApi.Models.Generic;
using coreLogic.Helpers;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using WildHare.Extensions;

namespace coreApi.Data;

public class MessageRepo(CoreApiDataContext coreApiDataContext) : IMessageRepo
{

	public async Task<List<Message>> GetAllMessages()
	{
		return await coreApiDataContext.Messages.ToListAsync();
	}

	public async Task<Message> SaveMessage(Message message)
	{
		coreApiDataContext.Update(message);
		await coreApiDataContext.SaveChangesAsync();

		return message;
	}
}
