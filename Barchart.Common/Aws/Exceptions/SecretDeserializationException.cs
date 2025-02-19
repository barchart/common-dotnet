namespace Barchart.Common.Aws.Exceptions;

/// <summary>
///     Thrown when a secret value cannot be deserialized.
/// </summary>
public class SecretDeserializationException : InvalidOperationException
{
    #region Constructor(s)

    /// <summary>
    ///     Initializes a new instance of the <see cref="SecretDeserializationException"/> class.
    /// </summary>
    /// <param name="secretName">
    ///     The name of the secret that could not be deserialized.
    /// </param>
    public SecretDeserializationException(string secretName) : base($"The secret ({secretName}) could not be deserialized.")
    {
        
    }

    #endregion
}