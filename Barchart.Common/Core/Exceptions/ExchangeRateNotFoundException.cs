namespace Barchart.Common.Core.Exceptions;

/// <summary>
///     Thrown when the exchange rate for a specific currency pair is not found.
/// </summary>
public class ExchangeRateNotFoundException : InvalidOperationException
{
    #region Constructor(s)
    
    public ExchangeRateNotFoundException(Currency source, Currency target) : base($"The exchange rate for the ({source}) to ({target}) currency pair was not found.")
    {
        
    }
    
    #endregion
    
}