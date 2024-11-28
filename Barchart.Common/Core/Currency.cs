namespace Barchart.Common.Core;

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
    
    public static Currency? FromCode<T>(string code) where T : Currency
    {
        return FromCode(typeof(T), code);
    }

    public static Currency? FromCode(Type type, string code)
    {
        return GetItems(type).FirstOrDefault(x => x.Code == code);
    }

    public static IEnumerable<Currency> GetItems(Type type)
    {
        return Types.TryGetValue(type, out List<Currency>? items) ? items : Enumerable.Empty<Currency>();
    }

    public static Currency? Parse(string code)
    {
        return FromCode<Currency>(code);
    }

    public static bool TryParse(string code, out Currency? currency)
    {
        currency = FromCode<Currency>(code);
        return currency != null;
    }

    public override bool Equals(object? obj)
    {
        return obj is Currency other && other.GetType() == GetType() && other.Code == Code;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(GetType(), Code);
    }
    
    #endregion
}