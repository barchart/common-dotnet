namespace Barchart.Common.Core.Exceptions;

/// <summary>
///     Thrown when the exchange rate for a specific currency pair is not found.
/// </summary>
public class ExchangeRateNotFoundException : InvalidOperationException
{
    #region Constructor(s)
    
    /// <summary>
    ///    Initializes a new instance of the <see cref="ExchangeRateNotFoundException"/> class.
    /// </summary>
    /// <param name="source">
    ///     The source currency.
    /// </param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    public ExchangeRateNotFoundException(Currency source, Currency target) : base($"The exchange rate for the ({source}) to ({target}) currency pair was not found.")
    {
        
    }
    
    #endregion
    
}