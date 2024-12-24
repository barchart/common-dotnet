namespace Barchart.Common.Collections.Exceptions;

/// <summary>
///     Thrown when the value of the limit parameter is invalid.
/// </summary>
public class InvalidQueueLimitException : ArgumentOutOfRangeException
{
    #region Constructor(s)

    public InvalidQueueLimitException(int limit) : base($"The value of the limit parameter ({limit}) is invalid. The limit must be greater than zero.")
    {
        
    }
    
    #endregion
}