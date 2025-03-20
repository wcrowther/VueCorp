using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace coreApi.Models;

public class UserToCreate : User
{
    [Required]
    public string Password { get; init; }
}