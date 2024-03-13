using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class AuthSignup
{
    [Required]
    public string UserName { get; set; } 

    [Required]
    public string Password { get; set; }

	public string UserEmail { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }
}