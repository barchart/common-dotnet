namespace Barchart.Common.Utilities;

/// <summary>
///     Class representing currency information.
/// </summary>
public class CurrencyInfo
{
    /// <summary>
    ///     The description of the currency.
    /// </summary>
    public string Description { get; }
    
    /// <summary>
    ///     The precision of the currency.
    /// </summary>
    public int Precision { get; }
    
    /// <summary>
    ///     The alternate description of the currency.
    /// </summary>
    public string AlternateDescription { get; }

    public CurrencyInfo(string description, int precision, string alternateDescription)
    {
        Description = description;
        Precision = precision;
        AlternateDescription = alternateDescription;
    }
}