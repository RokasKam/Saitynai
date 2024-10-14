using System.ComponentModel.DataAnnotations;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Requests.Hike;

public class HikeRequest
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Difficulty Level is required.")]
    public DifficultyLevelEnum DifficultyLevel { get; set; }

    [Required(ErrorMessage = "Total Distance is required.")]
    public double TotalDistance { get; set; }

    [Required(ErrorMessage = "Total Duration is required.")]
    public double TotalDurationInMinutes { get; set; }

    [Required(ErrorMessage = "Total Elevation Gain is required.")]
    public double TotalElevationGain { get; set; }

    [Required(ErrorMessage = "Seasonality is required.")]
    public SeasonalityEnum Seasonality { get; set; }

    [Required(ErrorMessage = "Terrain Type is required.")]
    public TerrainTypeEnum TerrainType { get; set; }

    [Required(ErrorMessage = "Suitability for Beginners is required.")]
    public bool SuitableForBeginners { get; set; }

    [Required(ErrorMessage = "Accessibility is required.")]
    public AccessibilityEnum Accessibility { get; set; }
}