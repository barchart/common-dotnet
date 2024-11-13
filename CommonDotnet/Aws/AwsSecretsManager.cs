#region Using Statements

using Amazon;
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

    private readonly string _region;

    #endregion
    
    #region Constructor(s)

    /// <summary>
    ///     Initializes a new instance of the <see cref="AwsSecretsManager"/> class.
    /// </summary>
    /// <param name="region">
    ///     The AWS region in which the Secrets Manager service is located.
    /// </param>
    public AwsSecretsManager(string region = "us-east-1")
    {
        _region = region;
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
    public async Task<string> GetSecret(string secretName)
    {
        IAmazonSecretsManager client = new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(_region));

        GetSecretValueRequest request = new GetSecretValueRequest
        {
            SecretId = secretName,
            VersionStage = "AWSCURRENT"
        };

        GetSecretValueResponse response;

        try
        {
            response = await client.GetSecretValueAsync(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving secret: {ex.Message}");
            
            throw;
        }

        return response.SecretString;
    }
    
    #endregion
}
