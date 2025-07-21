using coreApi.Models;

namespace coreLogic.Interfaces;

public interface IMessageManager
{
	Task<List<Message>> GetAllMessages();

	Task<int> GetMaxMessageId();

	Task<Message> SaveMessage(Message message);
}