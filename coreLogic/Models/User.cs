
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace coreApi.Models;

public class User
{
	public int UserId { get; set; }

	[Required, Length(5,50, ErrorMessage = $"The {nameof(UserName)} property must be 5 or more characters and 50 or less.")]
	public string UserName { get; set; }

	[Required, MaxLength(50)]
	public string FirstName { get; set; } 

	[Required, MaxLength(50)]
	public string LastName { get; set; } 

	[Required, MaxLength(50)]
	[EmailAddress(ErrorMessage = $"The {nameof(UserEmail)} property must be an Email Address.")]
    public string UserEmail { get; set; } 

    [JsonIgnore]
    public string PasswordHash { get; set; }

	[AllowedValues("User", "Admin", "SuperAdmin")]
	public string Role { get; set; }

	public string RefreshToken { get; set; }

	public DateTime RefreshTokenExpiration { get; set; }

	public override string ToString() => $"{FirstName} {LastName} Id: {UserId}";
}
