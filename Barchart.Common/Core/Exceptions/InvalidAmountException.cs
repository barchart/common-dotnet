namespace Barchart.Common.Core.Exceptions;

/// <summary>
///     Thrown when an invalid amount is provided.
/// </summary>
public class InvalidAmountException : ArgumentOutOfRangeException
{
    #region Constructor(s)
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="InvalidAmountException"/> class.
    /// </summary>
    /// <param name="amount">
    ///     The amount that is invalid.
    /// </param>
    public InvalidAmountException(float amount) : base($"The amount({amount}) must be a number greater or equal to zero.")
    {
        
    }
    
    #endregion
}