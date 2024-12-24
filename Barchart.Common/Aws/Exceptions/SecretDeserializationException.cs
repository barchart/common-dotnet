namespace Barchart.Common.Aws.Exceptions;

/// <summary>
///     Thrown when a secret value cannot be deserialized.
/// </summary>
public class SecretDeserializationException : InvalidOperationException
{
    #region Constructor(s)

    public SecretDeserializationException(string secretName) : base($"The secret ({secretName}) could not be deserialized.")
    {
        
    }

    #endregion
}