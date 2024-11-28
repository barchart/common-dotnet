namespace Barchart.Common.Core;

/// <summary>
///     Represents a utility class that provides information about currencies.
/// </summary>
public class Currency
{
    #region Fields

    private static readonly List<Currency> Currencies = new();

    #endregion

    #region Properties

    public static Currency AUD { get; } = new("AUD", "Australian Dollar", 2, "AUD$");
    public static Currency CAD { get; } = new("CAD", "Canadian Dollar", 2, "CAD$");
    public static Currency CHF { get; } = new("CHF", "Swiss Franc", 2, "CHF");
    public static Currency EUR { get; } = new("EUR", "Euro", 2, "EUR");
    public static Currency GBP { get; } = new("GBP", "British Pound", 2, "GBP");
    public static Currency GBX { get; } = new("GBX", "British Penny", 2, "GBX");
    public static Currency HKD { get; } = new("HKD", "Hong Kong Dollar", 2, "HK$");
    public static Currency JPY { get; } = new("JPY", "Japanese Yen", 2, "JPY");
    public static Currency USD { get; } = new("USD", "US Dollar", 2, "US$");

    public string Code { get; }
    public string Description { get; }
    public int Precision { get; }
    public string AlternateDescription { get; }

    #endregion

    #region Constructor(s)

    public Currency(string code, string description, int precision, string? alternateDescription = null)
    {
        if (string.IsNullOrEmpty(code))
        {
            throw new ArgumentException("Code is required", nameof(code));
        }

        if (string.IsNullOrEmpty(description))
        {
            throw new ArgumentException("Description is required", nameof(description));
        }

        if (precision < 0)
        {
            throw new ArgumentException("Precision must be a non-negative integer", nameof(precision));
        }

        Code = code;
        Description = description;
        Precision = precision;
        AlternateDescription = alternateDescription ?? description;

        if (Currencies.All(c => c.Code != code))
        {
            Currencies.Add(this);
        }
    }

    #endregion

    #region Methods

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
        return Currencies.FirstOrDefault(x => x.Code.Equals(code, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    ///     Returns all currencies.
    /// </summary>
    /// <returns>
    ///     All currencies.
    /// </returns>
    public static IEnumerable<Currency> GetItems()
    {
        return Currencies.AsReadOnly();
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
        currency = FromCode(code);
        return currency != null;
    }

    public override bool Equals(object? obj)
    {
        return obj is Currency other && other.Code == Code;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Code);
    }

    #endregion
}
