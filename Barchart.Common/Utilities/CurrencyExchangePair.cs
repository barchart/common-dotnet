using Barchart.Common.Core;

namespace Barchart.Common.Utilities;

/// <summary>
///     Represents a pair of currencies for which an exchange rate is defined.
/// </summary>
public sealed class CurrencyExchangePair : IEquatable<CurrencyExchangePair>
{
    #region Properties
        
    /// <summary>
    ///     The source currency.
    /// </summary>
    public Currency Source { get; }
    
    /// <summary>
    ///     The target currency.
    /// </summary>
    public Currency Target { get; }
        
    #endregion

    #region Constructor(s)

    public CurrencyExchangePair(Currency source, Currency target)
    {
        Source = source;
        Target = target;
    }

    #endregion

    #region Methods
        
    public override bool Equals(object? obj)
    {
        return Equals(obj as CurrencyExchangePair);
    }

    public bool Equals(CurrencyExchangePair? other)
    {
        return other != null && Source.Equals(other.Source) && Target.Equals(other.Target);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Source, Target);
    }
        
    #endregion
}