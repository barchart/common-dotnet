namespace Barchart.Common.Extensions;

/// <summary>
///     Provides extension methods for the <see cref="DateOnly"/> type.
/// </summary>
public static class DateOnlyExtensions
{
    #region Methods

    /// <summary>
    ///     Gets the number of days since the epoch.
    /// </summary>
    /// <param name="date">
    ///     The date to get the number of days since the epoch for.
    /// </param>
    /// <returns>
    ///     The number of days since the epoch.
    /// </returns>
    public static int GetDaysSinceEpoch(this DateOnly date)
    {
        return date.DayNumber - DateOnly.MinValue.DayNumber;
    }
    
    #endregion
}