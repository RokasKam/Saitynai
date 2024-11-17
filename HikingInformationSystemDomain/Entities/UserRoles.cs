namespace HikingInformationSystemDomain.Entities;

public static class UserRoles
{
    public const string Admin = nameof(Admin);
    public const string Hiker = nameof(Hiker);
    public const string Organizer = nameof(Organizer);

    public static readonly IReadOnlyCollection<string> All = [Admin, Hiker, Organizer];
}