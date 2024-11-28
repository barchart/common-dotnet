namespace Barchart.Common.Core;

/// <summary>
///     Represent a utility class for converting between currencies.
/// </summary>
public class CurrencyConverter
{
    #region Fields
    
    private readonly Dictionary<(Currency, Currency), float> _exchangeRates = new();
    
    #endregion

    #region Methods
    
    /// <summary>
    ///     Sets or updates the exchange rate for a specific currency pair. Reverse rate will be automatically calculated and stored.
    /// </summary>
    /// <param name="source">
    ///     The source currency.</param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    /// <param name="rate">
    ///     The exchange rate between the source and target currencies.
    /// </param>
    public void SetExchangeRate(Currency source, Currency target, float rate)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (target == null) throw new ArgumentNullException(nameof(target));
        if (rate <= 0) throw new ArgumentException("Exchange rate must be a positive number.", nameof(rate));

        _exchangeRates[(source, target)] = rate;
        _exchangeRates[(target, source)] = 1 / rate;
    }

    /// <summary>
    ///     Converts an amount from one currency to another using the previously set exchange rates.
    /// </summary>
    /// <param name="source">
    ///     The source currency.
    /// </param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    /// <param name="amount">
    ///     The amount in the source currency.
    /// </param>
    /// <returns>
    ///     The amount in the target currency.
    /// </returns>
    public float Convert(Currency source, Currency target, float amount)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));
        if (target == null) throw new ArgumentNullException(nameof(target));
        if (amount < 0) throw new ArgumentException("Amount must be a non-negative number.", nameof(amount));

        if (Equals(source, target)) return amount;

        if (!_exchangeRates.TryGetValue((source, target), out float rate))
        {
            throw new InvalidOperationException($"Exchange rate from {source.Code} to {target.Code} is not available.");
        }

        return amount * rate;
    }

    /// <summary>
    ///     Checks if there is a direct exchange rate between two currencies.
    /// </summary>
    /// <param name="source">
    ///     The source currency.
    /// </param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    /// <returns>
    ///     True if an exchange rate exists, false otherwise.
    /// </returns>
    public bool HasExchangeRate(Currency source, Currency target)
    {
        return _exchangeRates.ContainsKey((source, target));
    }
    
    #endregion
}