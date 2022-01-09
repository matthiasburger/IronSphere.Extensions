namespace IronSphere.Extensions;

/// <summary>
/// This enum provides all possible types for iterating in a <see cref="DateTimeSpan"/>
/// </summary>
public enum DateTimeSpanType
{
    /// <summary>
    /// ticks
    /// </summary>
    Ticks, 

    /// <summary>
    /// milliseconds
    /// </summary>
    Milliseconds, 
        
    /// <summary>
    /// seconds
    /// </summary>
    Seconds,
        
    /// <summary>
    /// minutes
    /// </summary>
    Minutes, 

    /// <summary>
    /// hours
    /// </summary>
    Hours, 

    /// <summary>
    /// days
    /// </summary>
    Days, 

    /// <summary>
    /// months
    /// </summary>
    Months, 

    /// <summary>
    /// years
    /// </summary>
    Years
}