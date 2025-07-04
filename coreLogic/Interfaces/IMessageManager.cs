using coreApi.Models;

namespace coreLogic.Interfaces;

public interface IMessageManager
{
	Task<List<Message>> GetAllMessages();

	Task<Message> SaveMessage(Message message);
}