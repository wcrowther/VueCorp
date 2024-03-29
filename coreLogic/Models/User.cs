
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace coreApi.Models;

public class User
{
    public int UserId { get; set; }

	[Required, MaxLength(50)]
	public string UserName { get; set; }

	[Required, MaxLength(50)]
	public string FirstName { get; set; } 

	[Required, MaxLength(50)]
	public string LastName { get; set; } 

	[Required, MaxLength(50)]
	[EmailAddress(ErrorMessage = "The User.Username property must be an Email Address.")]
    public string UserEmail { get; set; } 

    [JsonIgnore]
    public string PasswordHash { get; set; }

	[MaxLength(100)]
	public string Roles { get; set; } = "User";  // "User", "Admin", or "User,Admin"

    public override string ToString() => $"{FirstName} {LastName} Id: {UserId}";

}
