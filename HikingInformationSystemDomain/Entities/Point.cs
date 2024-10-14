namespace HikingInformationSystemDomain.Entities;

public class Point : BaseEntity
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Altitude { get; set; }
    public FeatureType Feature { get; set; }
    public string FeatureDescription { get; set; }
    public PointType PointType { get; set; }
    public string Image { get; set; } 
    public int OrderInRoute { get; set; } 
    public Guid RouteId { get; set; }
    public Route Route { get; set; }
}

public enum FeatureType
{
    Viewpoint,
    Landmark,
    Historic,
    Waterfall,
    Campsite,
    Shelter,
    Bridge,
    Cave,
    PicnicArea,
    RiverCrossing,
    ParkingArea,
    TrailIntersection
}

public enum PointType
{
    Startpoint,
    Endpoint,
    Viewpoint,
    Waypoint,
    Checkpoint,
    EmergencyExit
}