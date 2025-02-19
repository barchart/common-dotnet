namespace Barchart.Common.Collections.Exceptions;

/// <summary>
///     Thrown when the value of the limit parameter is invalid.
/// </summary>
public class InvalidQueueLimitException : ArgumentOutOfRangeException
{
    #region Constructor(s)

    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidQueueLimitException"/> class with the specified limit.
    /// </summary>
    /// <param name="limit">
    ///     The value of the limit parameter that caused the exception.
    /// </param>
    public InvalidQueueLimitException(int limit) : base($"The value of the limit parameter ({limit}) is invalid. The limit must be greater than zero.")
    {
        
    }
    
    #endregion
}