namespace Barchart.Common.Core.Exceptions;

/// <summary>
///     Thrown when an invalid exchange rate is provided.
/// </summary>
public class InvalidExchangeRateException : ArgumentOutOfRangeException
{
    #region Constructor(s)
    
    public InvalidExchangeRateException(float exchangeRate) : base($"The exchange rate ({exchangeRate}) must be a positive number.")
    {
        
    }
    
    #endregion
}