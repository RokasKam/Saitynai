namespace HikingInformationSystemDomain.Entities;

public class Hike : BaseEntity
{
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
    public ICollection<Route> Routes { get; set; }
}

public enum DifficultyLevelEnum
{
    Easy,
    Moderate,
    Hard,
    Expert
}

public enum SeasonalityEnum
{
    Spring,
    Summer,
    Fall,
    Winter,
    YearRound
}

public enum TerrainTypeEnum
{
    Forest,
    Mountain,
    Desert,
    Coastal,
    Urban
}

public enum AccessibilityEnum
{
    WheelchairFriendly,
    DogFriendly,
    ChildFriendly,
    SeniorFriendly,
    NonAccessible
}