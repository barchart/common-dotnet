namespace Barchart.Common.Core.Exceptions;

/// <summary>
///     Thrown when an invalid amount is provided.
/// </summary>
public class InvalidAmountException : ArgumentOutOfRangeException
{
    #region Constructor(s)
    
    public InvalidAmountException(float amount) : base($"The amount({amount}) must be a number greater or equal to zero.")
    {
        
    }
    
    #endregion
}