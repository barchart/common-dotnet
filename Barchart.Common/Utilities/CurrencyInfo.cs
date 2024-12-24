namespace Barchart.Common.Utilities;

/// <summary>
///     Class representing currency information.
/// </summary>
public class CurrencyInfo
{
    #region Properties
    
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

    #endregion

    #region Constructor(s)
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="CurrencyInfo"/> class.
    /// </summary>
    /// <param name="description">
    ///     The description of the currency.
    /// </param>
    /// <param name="precision">
    ///     The precision of the currency.
    /// </param>
    /// <param name="alternateDescription">
    ///     The alternate description of the currency.
    /// </param>
    /// <exception cref="ArgumentException">
    ///     Thrown when <paramref name="description"/> or <paramref name="alternateDescription"/> is <see langword="null"/> or empty.
    /// </exception>
    public CurrencyInfo(string description, int precision, string alternateDescription)
    {
        ArgumentException.ThrowIfNullOrEmpty(description);
        ArgumentException.ThrowIfNullOrEmpty(alternateDescription);
        
        Description = description;
        Precision = precision;
        AlternateDescription = alternateDescription;
    }
    #endregion

}