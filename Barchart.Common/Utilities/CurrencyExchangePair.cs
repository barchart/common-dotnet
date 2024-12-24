#region Using Statements

using Barchart.Common.Core;

#endregion

namespace Barchart.Common.Utilities;

/// <summary>
///     Represents a pair of currencies for which an exchange rate is defined.
/// </summary>
internal class CurrencyExchangePair : IEquatable<CurrencyExchangePair>
{
    #region Properties
        
    /// <summary>
    ///     The source currency.
    /// </summary>
    internal Currency Source { get; }
    
    /// <summary>
    ///     The target currency.
    /// </summary>
    internal Currency Target { get; }
        
    #endregion

    #region Constructor(s)

    /// <summary>
    ///     Initializes a new instance of the <see cref="CurrencyExchangePair"/> class.
    /// </summary>
    /// <param name="source">
    ///     The source currency.
    /// </param>
    /// <param name="target">
    ///     The target currency.
    /// </param>
    ///<exception cref="ArgumentNullException">
    ///     Thrown when <paramref name="source"/> or <paramref name="target"/> is <see langword="null"/>.
    /// </exception>
    internal CurrencyExchangePair(Currency source, Currency target)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        ArgumentNullException.ThrowIfNull(target, nameof(target));
        
        Source = source;
        Target = target;
    }

    #endregion

    #region Methods
    
    /// <inheritdoc />
    public bool Equals(CurrencyExchangePair? other)
    {
        return other != null && Source.Equals(other.Source) && Target.Equals(other.Target);
    }

    /// <inheritdoc />
    public override int GetHashCode()
    {
        return HashCode.Combine(Source, Target);
    }
        
    #endregion
}