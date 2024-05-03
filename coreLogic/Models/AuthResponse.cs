
namespace coreApi.Models;

public class AuthResponse(User user, DateTime expiration)
{
	public int UserId { get; set; } = user.UserId;

	public string FirstName { get; set; } = user.FirstName;

	public string LastName { get; set; } = user.LastName;

	public string UserName { get; set; } = user.UserName;

	public string UserEmail { get; set; } = user.UserEmail;

	public DateTime Expiration { get; set; } = expiration;

	public string Token { get; set; }

	public override string ToString() => $"{UserName} ({UserId}) FullName: {FirstName} {LastName}";

}