using System.ComponentModel.DataAnnotations;

namespace HikingInforamtionSystemCore.Requests.Auth;

public class RegisterRequest
{
    [EmailAddress]
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string UserName { get; set; }
}