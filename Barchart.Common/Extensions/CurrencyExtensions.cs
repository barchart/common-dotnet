using Barchart.Common.Core;
using Barchart.Common.Utilities;

namespace Barchart.Common.Extensions;

public static class CurrencyExtensions
{
    private static readonly Dictionary<Currency, CurrencyInfo> Currencies = new()
    {
        { Currency.AUD, new CurrencyInfo("Australian Dollar", 2, "AUD$") },
        { Currency.CAD, new CurrencyInfo("Canadian Dollar", 2, "CAD$") },
        { Currency.CHF, new CurrencyInfo("Swiss Franc", 2, "CHF") },
        { Currency.EUR, new CurrencyInfo("Euro", 2, "EUR") },
        { Currency.GBP, new CurrencyInfo("British Pound", 2, "GBP") },
        { Currency.GBX, new CurrencyInfo("British Penny", 2, "GBX") },
        { Currency.HKD, new CurrencyInfo("Hong Kong Dollar", 2, "HK$") },
        { Currency.JPY, new CurrencyInfo("Japanese Yen", 2, "JPY") },
        { Currency.USD, new CurrencyInfo("US Dollar", 2, "US$") }
    };
    
    public static string GetDescription(this Currency currency)
    {
        return Currencies[currency].Description;
    }

    public static int GetPrecision(this Currency currency)
    {
        return Currencies[currency].Precision;
    }

    public static string GetAlternateDescription(this Currency currency)
    {
        return Currencies[currency].AlternateDescription;
    }

    /// <summary>
    ///     Returns the currency with the specified code.
    /// </summary>
    /// <param name="code">
    ///     The currency code.
    /// </param>
    /// <returns>
    ///     The currency with the specified code, or <see langword="null"/> if no currency with the specified code is found.
    /// </returns>
    public static Currency? FromCode(string code)
    {
        return Enum.TryParse<Currency>(code, true, out var currency) ? currency : null;
    }

    /// <summary>
    ///     Returns all currencies.
    /// </summary>
    /// <returns>
    ///     All currencies.
    /// </returns>
    public static IEnumerable<Currency> GetItems()
    {
        return Enum.GetValues(typeof(Currency)).Cast<Currency>();
    }

    /// <summary>
    ///     Tries to parse a currency code into a currency object.
    /// </summary>
    /// <param name="code">
    ///     The currency code.
    /// </param>
    /// <param name="currency">
    ///     The resulting currency object.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if parsing was successful; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryParse(string code, out Currency? currency)
    {
        if (Enum.TryParse<Currency>(code, true, out var parsedCurrency))
        {
            currency = parsedCurrency;
            return true;
        }

        currency = null;
        return false;
    }
}