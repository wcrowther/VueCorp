namespace coreApi.Models;

public record MessageDto(int MessageId, string MessageText, string CreatorName, DateTime DateCreated);
