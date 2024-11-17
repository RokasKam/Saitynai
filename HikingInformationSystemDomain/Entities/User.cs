using Microsoft.AspNetCore.Identity;

namespace HikingInformationSystemDomain.Entities;

public class User : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public ICollection<Hike> Hikes { get; set; }
}