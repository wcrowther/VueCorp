
namespace coreApi.Models;

public class AuthResponse(User user, DateTime expiration)
{
	public int UserId { get; init; } = user.UserId;

	public string FirstName { get; set; } = user.FirstName;

	public string LastName { get; init; } = user.LastName;

	public string UserName { get; init; } = user.UserName;

	public string UserEmail { get; init; } = user.UserEmail;

	public DateTime Expiration { get; init; } = expiration;

	public string Token { get; set; }

	public override string ToString() => $"{UserName} ({UserId}) FullName: {FirstName} {LastName}";

}