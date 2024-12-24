#region Using Statements

using Amazon;
using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

using System.Text.Json;
using Barchart.Common.Aws.Exceptions;

#endregion

namespace Barchart.Common.Aws;

/// <summary>
///     Provides functionality to communicate with an AWS Secrets Manager service to retrieve secret values.
/// </summary>
public class AwsSecretsManager
{
    #region Fields

    private readonly IAmazonSecretsManager _secretsManager;

    #endregion
    
    #region Constructor(s)
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="AwsSecretsManager"/> class.
    /// </summary>
    /// <param name="secretsManager">
    ///     The AWS Secrets Manager client to use.
    /// </param>
    /// <exception cref="ArgumentNullException">
    ///     Thrown when the <paramref name="secretsManager"/> parameter is <see langword="null"/>.
    /// </exception>
    public AwsSecretsManager(IAmazonSecretsManager secretsManager)
    {
        ArgumentNullException.ThrowIfNull(secretsManager, nameof(secretsManager));
        
        _secretsManager = secretsManager;
    }
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="AwsSecretsManager"/> class.
    /// </summary>
    /// <param name="region">
    ///     The AWS region in which the Secrets Manager service is located.
    /// </param>
    public AwsSecretsManager(string region = "us-east-1") : this(new AmazonSecretsManagerClient(RegionEndpoint.GetBySystemName(region)))
    {
        
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
    /// <exception cref="ArgumentException">
    ///     Thrown when the <paramref name="secretName"/> parameter is <see langword="null"/> or whitespace.
    /// </exception>
    /// <exception cref="SecretNotFoundException">
    ///     Thrown when the secret cannot be found.
    /// </exception>
    public async Task<string> GetSecret(string secretName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(secretName, nameof(secretName));
        
        GetSecretValueRequest request = new()
        {
            SecretId = secretName,
            VersionStage = "AWSCURRENT"
        };

        GetSecretValueResponse response;

        try
        {
            response = await _secretsManager.GetSecretValueAsync(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving secret: {ex.Message}");
            
            throw new SecretNotFoundException(secretName);
        }

        return response.SecretString;
    }

    /// <summary>
    ///     Retrieves the value of a secret from the AWS Secrets Manager service.
    /// </summary>
    /// <param name="secretName">
    ///     The name of the secret to retrieve.
    /// </param>
    /// <typeparam name="T">
    ///     The type to which the secret value should be deserialized.
    /// </typeparam>
    /// <returns>
    ///     The value of the secret.
    /// </returns>
    /// <exception cref="ArgumentException">
    ///     Thrown when the <paramref name="secretName"/> parameter is <see langword="null"/> or whitespace.
    /// </exception>
    /// <exception cref="SecretNotFoundException">
    ///     Thrown when the secret cannot be found.
    /// </exception>
    /// <exception cref="SecretDeserializationException">
    ///     Thrown when the secret value cannot be deserialized.
    /// </exception>
    public async Task<T> GetSecret<T>(string secretName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(secretName, nameof(secretName));

        GetSecretValueRequest request = new()
        {
            SecretId = secretName,
            VersionStage = "AWSCURRENT"
        };

        GetSecretValueResponse response;

        try
        {
            response = await _secretsManager.GetSecretValueAsync(request);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving secret: {ex.Message}");
            
            throw new SecretNotFoundException(secretName);
        }
        
        T? deserialized = JsonSerializer.Deserialize<T>(response.SecretString);
        
        if (deserialized == null)
        {
            throw new SecretDeserializationException(secretName);
        }

        return deserialized;
    }
    
    #endregion
}