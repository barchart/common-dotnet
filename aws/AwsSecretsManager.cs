#region Using Statements

using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

#endregion

namespace common_dotnet.aws;

/// <summary>
/// 
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
