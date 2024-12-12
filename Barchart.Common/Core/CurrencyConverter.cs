using Barchart.Common.Utilities;

namespace Barchart.Common.Core;

/// <summary>
///     Utility class for managing and converting between currencies using predefined exchange rates.
/// </summary>
public class CurrencyConverter
{
    #region Fields

    private readonly IDictionary<CurrencyExchangePair, float> _exchangeRates = new Dictionary<CurrencyExchangePair, float>();

    #endregion

    #region Methods

    /// <summary>
    ///     Sets or updates the exchange rate for a specific currency pair. Automatically calculates and stores the reverse rate.
    /// </summary>
    /// <param name="source">
    ///     The source currency.
    /// </param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    /// <param name="rate">
    ///     The exchange rate from the source to the target currency.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source"/> or <paramref name="target"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="rate"/> is not a positive number.
    /// </exception>
    public void SetExchangeRate(Currency source, Currency target, float rate)
    {
        if (rate <= 0)
        {
            throw new ArgumentException("Exchange rate must be a positive number.", nameof(rate));
        }
        
        CurrencyExchangePair pair = new(source, target);
        CurrencyExchangePair reversePair = new(target, source);

        _exchangeRates[pair] = rate;
        _exchangeRates[reversePair] = 1 / rate;
    }
    
    /// <summary>
    ///    Returns the exchange rate between two currencies.
    /// </summary>
    /// <param name="source">
    ///     The source currency.
    /// </param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    /// <returns>
    ///     The exchange rate from the source to the target currency.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source"/> or <paramref name="target"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     The exchange rate between the specified currencies is not available.
    /// </exception>
    public float GetExchangeRate(Currency source, Currency target)
    {
        CurrencyExchangePair pair = new(source, target);

        if (!_exchangeRates.TryGetValue(pair, out float rate))
        {
            throw new InvalidOperationException($"Exchange rate from {source} to {target} is not available.");
        }

        return rate;
    }

    /// <summary>
    ///     Converts an amount from one currency to another using the predefined exchange rates.
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
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source"/> or <paramref name="target"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    ///     <paramref name="amount"/> is not a positive number.
    /// </exception>
    /// <exception cref="InvalidOperationException">
    ///     The exchange rate between the specified currencies is not available.
    /// </exception>
    public float Convert(Currency source, Currency target, float amount)
    {
        if (amount < 0)
        {
            throw new ArgumentException("Amount must be a non-negative number.", nameof(amount));
        }

        if (Equals(source, target))
        {
            return amount;
        }

        CurrencyExchangePair pair = new(source, target);

        if (!_exchangeRates.TryGetValue(pair, out float rate))
        {
            throw new InvalidOperationException($"Exchange rate from {source} to {target} is not available.");
        }

        return amount * rate;
    }

    /// <summary>
    ///     Checks if a direct exchange rate is available between two currencies.
    /// </summary>
    /// <param name="source">
    ///     The source currency.
    /// </param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    /// <returns>
    ///     True if an exchange rate exists, otherwise false.
    /// </returns>
    /// <exception cref="ArgumentNullException">
    ///     <paramref name="source"/> or <paramref name="target"/> is <see langword="null"/>.
    /// </exception>
    public bool HasExchangeRate(Currency source, Currency target)
    {
        CurrencyExchangePair pair = new(source, target);
        return _exchangeRates.ContainsKey(pair);
    }

    #endregion
}