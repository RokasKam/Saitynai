namespace HikingInformationSystemDomain.Entities;

public class Route : BaseEntity
{
    public int OrderInHike { get; set; }
    public string Description { get; set; }
    public double Distance { get; set; }
    public double DurationInMinutes { get; set; }
    public double ElevationChange { get; set; }
    public string NavigationNotes { get; set; }
    public TerrainType TerrainType { get; set; }
    public SurfaceType SurfaceType { get; set; }
    public Guid HikeId { get; set; }
    public Hike Hike { get; set; }
    public ICollection<Point> Points { get; set; }
}

public enum TerrainType 
{
    Mountain,
    Forest,
    Desert,
    Plains,
    Coastal,
    Hills,
    Wetlands,
    Urban,
    Tundra,
    Jungle
}

public enum SurfaceType 
{
    Paved,
    Gravel,
    Mud,
    Sand,
    Rock,
    Grass,
    Snow,
    Ice,
    Boardwalk,
    Cobblestone
}