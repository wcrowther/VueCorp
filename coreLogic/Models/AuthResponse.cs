
namespace coreApi.Models;

public class AuthResponse(User user, string token)
{
	public int UserId { get; init; } = user.UserId;

	public string FirstName { get; set; } = user.FirstName;

	public string LastName { get; init; } = user.LastName;

	public string UserName { get; init; } = user.UserName;

	public string UserEmail { get; init; } = user.UserEmail;

	public string Role { get; init; } = user.Role;

	public string Token { get; set; } = token;

	public string RefreshToken { get; init; } = user.RefreshToken;

	public DateTime RefreshTokenExpiration { get; init; } = user.RefreshTokenExpiration;

	public override string ToString() => $"{UserName} ({UserId}) FullName: {FirstName} {LastName}";

}