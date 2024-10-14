using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Responses.Point;

public class PointResponse
{
    public Guid Id { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Altitude { get; set; }
    public FeatureType Feature { get; set; }
    public string FeatureDescription { get; set; }
    public PointType PointType { get; set; }
    public string Image { get; set; } 
    public int OrderInRoute { get; set; } 
    public Guid RouteId { get; set; }
}