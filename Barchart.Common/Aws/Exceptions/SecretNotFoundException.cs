namespace Barchart.Common.Aws.Exceptions;

/// <summary>
///     Thrown when a secret is not found in the AWS Secrets Manager service.
/// </summary>
public class SecretNotFoundException : InvalidOperationException
{
    #region Constructor(s)
    
    public SecretNotFoundException(string secretName) : base($"The secret ({secretName}) could not be found in the AWS Secrets Manager service.")
    {
        
    }
    
    #endregion
}