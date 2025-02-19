namespace Barchart.Common.Aws.Exceptions;

/// <summary>
///     Thrown when a secret is not found in the AWS Secrets Manager service.
/// </summary>
public class SecretNotFoundException : InvalidOperationException
{
    #region Constructor(s)
    
    /// <summary>
    ///    Initializes a new instance of the <see cref="SecretNotFoundException"/> class.
    /// </summary>
    /// <param name="secretName">
    ///     The name of the secret that could not be found.
    /// </param>
    public SecretNotFoundException(string secretName) : base($"The secret ({secretName}) could not be found in the AWS Secrets Manager service.")
    {
        
    }
    
    #endregion
}