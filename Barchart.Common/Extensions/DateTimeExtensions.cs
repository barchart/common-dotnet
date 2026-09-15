namespace Barchart.Common.Extensions;

/// <summary>
///     Provides extension methods for the <see cref="DateTime"/> type.
/// </summary>
public static class DateTimeExtensions
{
    #region Methods

    /// <summary>
    ///     Gets the number of milliseconds since the epoch (1970-01-01).
    /// </summary>
    /// <param name="date">
    ///     The date to get the number of milliseconds since the epoch for.
    /// </param>
    /// <returns>
    ///    The number of milliseconds since the epoch.
    /// </returns>
    /// <remarks>
    ///     Values with an unspecified <see cref="DateTime.Kind"/> are treated as UTC.
    /// </remarks>
    public static long GetMillisecondsSinceUnixEpoch(this DateTime date)
    {
        DateTime normalizedDate = date.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(date, DateTimeKind.Utc) : date;

        return new DateTimeOffset(normalizedDate).ToUnixTimeMilliseconds();
    }
    
    #endregion
}
