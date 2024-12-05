namespace Barchart.Common.Extensions;

/// <summary>
///     Provides extension methods for the <see cref="DateOnly"/> type.
/// </summary>
public static class DateOnlyExtensions
{
    #region Methods

    /// <summary>
    ///     Gets the number of days since the epoch (0001-01-01).
    /// </summary>
    /// <param name="date">
    ///     The date to get the number of days since the epoch for.
    /// </param>
    /// <returns>
    ///     The number of days since the epoch.
    /// </returns>
    public static int GetDaysSinceEpoch(this DateOnly date)
    {
        return CountDaysBetween(DateOnly.MinValue, date);
    }
    
    /// <summary>
    ///     Gets the number of days between two dates.
    /// </summary>
    /// <param name="from">
    ///     The date to start counting from.
    /// </param>
    /// <param name="to">
    ///     The date to count to.
    /// </param>
    /// <returns>
    ///     The number of days between the two dates.
    /// </returns>
    public static int CountDaysBetween(this DateOnly from, DateOnly to)
    {
        return to.DayNumber - from.DayNumber;
    }
    
    #endregion
}