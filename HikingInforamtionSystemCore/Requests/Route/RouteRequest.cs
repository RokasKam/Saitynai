using System.ComponentModel.DataAnnotations;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Requests.Route;

public class RouteRequest
{
    [Required(ErrorMessage = "Order in hike is mandatory.")]
    public int OrderInHike { get; set; }

    [Required(ErrorMessage = "Description is mandatory.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Distance is mandatory.")]
    public double Distance { get; set; }

    [Required(ErrorMessage = "Duration in minutes is mandatory.")]
    public double DurationInMinutes { get; set; }

    [Required(ErrorMessage = "Elevation change is mandatory.")]
    public double ElevationChange { get; set; }

    [Required(ErrorMessage = "Navigation notes are mandatory.")]
    public string NavigationNotes { get; set; }

    [Required(ErrorMessage = "Terrain type is mandatory.")]
    public TerrainType TerrainType { get; set; }

    [Required(ErrorMessage = "Surface type is mandatory.")]
    public SurfaceType SurfaceType { get; set; }
    
    [Required(ErrorMessage = "Hike is mandatory.")]
    public Guid HikeId { get; set; }
}