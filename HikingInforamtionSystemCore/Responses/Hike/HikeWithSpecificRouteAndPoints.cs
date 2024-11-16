using HikingInforamtionSystemCore.Responses.Route;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Responses.Hike;

public class HikeWithSpecificRouteAndPoints
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DifficultyLevelEnum DifficultyLevel { get; set; }
    public double TotalDistance { get; set; }
    public double TotalDurationInMinutes { get; set; }
    public double TotalElevationGain { get; set; }
    public SeasonalityEnum Seasonality { get; set; }
    public TerrainTypeEnum TerrainType { get; set; }
    public bool SuitableForBeginners { get; set; }
    public AccessibilityEnum Accessibility { get; set; }
    public RouteWithPointsResponse RouteWithPoints { get; set; }
}