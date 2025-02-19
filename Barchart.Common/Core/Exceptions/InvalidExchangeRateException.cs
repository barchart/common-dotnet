namespace Barchart.Common.Core.Exceptions;

/// <summary>
///     Thrown when an invalid exchange rate is provided.
/// </summary>
public class InvalidExchangeRateException : ArgumentOutOfRangeException
{
    #region Constructor(s)
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidExchangeRateException"/> class.
    /// </summary>
    /// <param name="exchangeRate">
    ///     The exchange rate.
    /// </param>
    public InvalidExchangeRateException(float exchangeRate) : base($"The exchange rate ({exchangeRate}) must be a positive number.")
    {
        
    }
    
    #endregion
}