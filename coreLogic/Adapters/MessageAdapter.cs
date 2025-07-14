using coreApi.Models;
using Microsoft.Extensions.DependencyInjection;

namespace coreLogic.Adapters;

public static partial class Adapter
{
	public static MessageDto ToMessageDto(this Message message) 
	{
		return message == null ? null :
			new MessageDto
			(
				message.MessageId,
				message.MessageText,
				message.CreatorName,
				message.DateCreated
			);
	}

	public static List<MessageDto> ToMessageDtoList(this IEnumerable<Message> list)
	{
		return list?.Select(a => a.ToMessageDto()).ToList() ?? [];
	}
}