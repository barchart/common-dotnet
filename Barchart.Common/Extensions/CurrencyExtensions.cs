#region Using Statements

using Barchart.Common.Core;
using Barchart.Common.Utilities;

#endregion

namespace Barchart.Common.Extensions;

/// <summary>
///     Represents a currency.
/// </summary>
public static class CurrencyExtensions
{
    #region Fields
    
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
    
    #endregion

    #region Methods
    
    /// <summary>
    ///     Retrieves the description for the specified <see cref="Currency"/>.
    /// </summary>
    /// <param name="currency">
    ///     The <see cref="Currency"/> instance for which the description is requested.
    /// </param>
    /// <returns>
    ///     A <see cref="string"/> representing the description of the specified currency.
    /// </returns>
    public static string GetDescription(this Currency currency)
    {
        return Currencies[currency].Description;
    }

    /// <summary>
    ///     Retrieves the precision for the specified <see cref="Currency"/>
    /// </summary>
    /// <param name="currency">
    ///     The <see cref="Currency"/> instance for which the precision is requested.
    /// </param>
    /// <returns>
    ///     A <see cref="string"/> representing the precision of the specified currency.
    /// </returns>
    public static int GetPrecision(this Currency currency)
    {
        return Currencies[currency].Precision;
    }

    /// <summary>
    ///     Retrieves the alternate description for the specified <see cref="Currency"/>.
    /// </summary>
    /// <param name="currency">
    ///     The <see cref="Currency"/> instance for which the alternate description is requested.
    /// </param>
    /// <returns>
    ///     A <see cref="string"/> representing the alternate description of the specified currency.
    /// </returns>
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
        return Enum.TryParse(code, true, out Currency currency) ? currency : null;
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
        if (Enum.TryParse(code, true, out Currency parsedCurrency))
        {
            currency = parsedCurrency;
            return true;
        }

        currency = null;
        return false;
    }
    
    #endregion
}