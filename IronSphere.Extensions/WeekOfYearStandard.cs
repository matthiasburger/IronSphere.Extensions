namespace IronSphere.Extensions;

/// <summary>
/// This enum provides standards for week of year calculation.
/// </summary>
public enum WeekOfYearStandard
{
    /// <summary>
    /// DotNet-Standard
    /// </summary>
    DotNet,

    /// <summary>
    /// Iso-Standard
    /// </summary>
    Iso8601,
        
#if DEBUG
    // for unit-testing purposes
    NotImplemented
#endif
}