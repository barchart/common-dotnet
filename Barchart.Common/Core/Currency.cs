namespace Barchart.Common.Core;

/// <summary>
///     Represents a currency.
/// </summary>
public class Currency
{
    #region Fields
    
    private static readonly Dictionary<Type, List<Currency>> Types = new();
    
    #endregion

    #region Properties
    
    public static Currency AUD { get; } = new Currency("AUD", "Australian Dollar", 2, "AUD$");
    public static Currency CAD { get; } = new Currency("CAD", "Canadian Dollar", 2, "CAD$");
    public static Currency CHF { get; } = new Currency("CHF", "Swiss Franc", 2, "CHF");
    public static Currency EUR { get; } = new Currency("EUR", "Euro", 2, "EUR");
    public static Currency GBP { get; } = new Currency("GBP", "British Pound", 2, "GBP");
    public static Currency GBX { get; } = new Currency("GBX", "British Penny", 2, "GBX");
    public static Currency HKD { get; } = new Currency("HKD", "Hong Kong Dollar", 2, "HK$");
    public static Currency JPY { get; } = new Currency("JPY", "Japanese Yen", 2, "JPY");
    public static Currency USD { get; } = new Currency("USD", "US Dollar", 2, "US$");

    public string Code { get; }
    public string Description { get; }
    public int Precision { get; }
    public string AlternateDescription { get; }

    #endregion

    #region Constructor(s)
    
    private Currency(string code, string description, int precision, string? alternateDescription = null)
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

        var type = GetType();

        if (!Types.ContainsKey(type))
        {
            Types[type] = new List<Currency>();
        }

        if (FromCode(type, code) == null)
        {
            Types[type].Add(this);
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
    /// <typeparam name="T">
    ///     The type of currency.
    /// </typeparam>
    /// <returns>
    ///     The currency with the specified code, or <see langword="null"/> if no currency with the specified code is found.
    /// </returns>
    public static Currency? FromCode<T>(string code) where T : Currency
    {
        return FromCode(typeof(T), code);
    }

    /// <summary>
    ///     Returns the currency with the specified code.
    /// </summary>
    /// <param name="type">
    ///     The type of currency.
    /// </param>
    /// <param name="code">
    ///     The currency code.
    /// </param>
    /// <returns>
    ///     The currency with the specified code, or <see langword="null"/> if no currency with the specified code is found.
    /// </returns>
    public static Currency? FromCode(Type type, string code)
    {
        return GetItems(type).FirstOrDefault(x => x.Code == code);
    }

    /// <summary>
    ///     Returns all currencies of the specified type.
    /// </summary>
    /// <param name="type">
    ///     The type of currency.
    /// </param>
    /// <returns>
    ///     All currencies of the specified type.
    /// </returns>
    public static IEnumerable<Currency> GetItems(Type type)
    {
        return Types.TryGetValue(type, out List<Currency>? items) ? items : Enumerable.Empty<Currency>();
    }

    /// <summary>
    ///     Returns all currencies of the specified type.
    /// </summary>
    /// <param name="code">
    ///     The currency code.
    /// </param>
    /// <returns>
    ///     All currencies of the specified type.
    /// </returns>
    public static Currency? Parse(string code)
    {
        return FromCode<Currency>(code);
    }

    /// <summary>
    ///     Returns all currencies of the specified type.
    /// </summary>
    /// <param name="code">
    ///    The currency code.
    /// </param>
    /// <param name="currency">
    ///     The currency.
    /// </param>
    /// <returns>
    ///    <see langword="true"/> if the currency was successfully parsed; otherwise, <see langword="false"/>.
    /// </returns>
    public static bool TryParse(string code, out Currency? currency)
    {
        currency = FromCode<Currency>(code);
        return currency != null;
    }

    /// <summary>
    ///     Returns the currency code.
    /// </summary>
    /// <param name="obj">
    ///     The currency.
    /// </param>
    /// <returns>
    ///     The currency code.
    /// </returns>
    public override bool Equals(object? obj)
    {
        return obj is Currency other && other.GetType() == GetType() && other.Code == Code;
    }

    /// <summary>
    ///     Returns the hash code.
    /// </summary>
    /// <returns>
    ///     The hash code.
    /// </returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Code);
    }
    
    #endregion
}