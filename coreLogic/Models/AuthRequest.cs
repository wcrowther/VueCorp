using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class AuthRequest
{
    [Required]
    public string UserName { get; set; } 

    [Required]
    public string Password { get; set; }

	public string UserEmail { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string Roles { get; set; } = "User";

	public override string ToString() => $"{UserName} FullName: {FirstName} {LastName} Role: {Roles}";
}