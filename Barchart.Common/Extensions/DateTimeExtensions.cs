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
    public static long GetMillisecondsSinceUnixEpoch(this DateTime date)
    {
        TimeSpan timeSpan = date - DateTime.UnixEpoch;

        return Convert.ToInt64(timeSpan.TotalMilliseconds);
    }
    
    #endregion
}