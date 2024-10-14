using HikingInforamtionSystemCore.Responses.Point;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Responses.Route;

public class RouteWithPointsResponse
{
    public Guid Id { get; set; }
    public int OrderInHike { get; set; }
    public string Description { get; set; }
    public double Distance { get; set; }
    public double DurationInMinutes { get; set; }
    public double ElevationChange { get; set; }
    public string NavigationNotes { get; set; }
    public TerrainType TerrainType { get; set; }
    public SurfaceType SurfaceType { get; set; }
    public Guid HikeId { get; set; }
    public IEnumerable<PointResponse> Points { get; set; }
}