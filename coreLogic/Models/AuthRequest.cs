using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class AuthRequest
{
    [Required]
    public string UserName { get; set; } 

    [Required]
    public string Password { get; set; }

    // Optional: 2FA code for login
    public string TwoFactorCode { get; set; }

    public override string ToString() => $"{UserName} : UserName";
}