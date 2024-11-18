using System.ComponentModel.DataAnnotations;

namespace HikingInforamtionSystemCore.Requests.Auth;

public class ChangeUserRole
{
    [Required]
    public string UserId { get; set; }
    [Required]
    public string NewRole { get; set; }
}