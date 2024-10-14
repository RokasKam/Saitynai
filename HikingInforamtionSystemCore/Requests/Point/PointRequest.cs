using System.ComponentModel.DataAnnotations;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Requests.Point;

public class PointRequest
{
    [Required(ErrorMessage = "Latitude is required.")]
    public double Latitude { get; set; }

    [Required(ErrorMessage = "Longitude is required.")]
    public double Longitude { get; set; }

    [Required(ErrorMessage = "Altitude is required.")]
    public double Altitude { get; set; }

    [Required(ErrorMessage = "Feature is required.")]
    public FeatureType Feature { get; set; }

    public string FeatureDescription { get; set; }

    [Required(ErrorMessage = "PointType is required.")]
    public PointType PointType { get; set; }

    public string Image { get; set; }

    [Required(ErrorMessage = "OrderInRoute is required.")]
    public int OrderInRoute { get; set; }

    [Required(ErrorMessage = "RouteId is required.")]
    public Guid RouteId { get; set; }
}