
namespace coreApi.Models;

public class AuthResponse
{
    public AuthResponse(User user, DateTime expiration)
    {
        UserId      = user.UserId;
        FirstName   = user.FirstName;
        LastName    = user.LastName;
        UserName    = user.UserName;
		UserEmail   = user.UserEmail;
        Expiration  = expiration;
    }

    public int UserId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

	public string UserName { get; set; }

	public string UserEmail { get; set; }

	public DateTime Expiration { get; set; }

    public string Token { get; set; }
}