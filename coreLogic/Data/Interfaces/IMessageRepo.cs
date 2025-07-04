using coreApi.Models;
using coreApi.Models.Generic;

namespace coreApi.Data.Interfaces;

public interface IMessageRepo
{
	Task<List<Message>> GetAllMessages();

	Task<Message> SaveMessage(Message message);
}