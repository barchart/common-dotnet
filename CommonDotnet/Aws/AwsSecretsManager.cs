#region Using Statements

using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

#endregion

namespace CommonDotnet.Aws;

/// <summary>
///     Provides functionality to communicate with an AWS Secrets Manager service to retrieve secret values.
/// </summary>
public class AwsSecretsManager
{
    #region Fields
    
    private readonly IAmazonSecretsManager _secretsManager;
    
    #endregion

    #region Constructor(s)

    public AwsSecretsManager(IAmazonSecretsManager secretsManager)
    {
        _secretsManager = secretsManager;
    }
    
    #endregion

    #region Methods

    /// <summary>
    ///     Retrieves the value of a secret from the AWS Secrets Manager service.
    /// </summary>
    /// <param name="secretName">
    ///     The name of the secret to retrieve.
    /// </param>
    /// <returns>
    ///     The value of the secret.
    /// </returns>
    public async Task<string> GetSecretValueAsync(string secretName)
    {
        try
        {
            GetSecretValueRequest request = new()
            {
                SecretId = secretName
            };

            GetSecretValueResponse? response = await _secretsManager.GetSecretValueAsync(request);
            return response.SecretString;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving secret: {ex.Message}");
            throw;
        }
    }
    
    #endregion
}
