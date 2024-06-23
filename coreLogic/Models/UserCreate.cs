using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class UserCreate : User
{
    [Required]
    public string Password { get; set; }
}