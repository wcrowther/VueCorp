using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class UserToCreate : User
{
    [Required]
    public string Password { get; set; }
}