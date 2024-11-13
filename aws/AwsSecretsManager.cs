using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

namespace common_dotnet.aws;

public class AwsSecretsManager
{
    private readonly IAmazonSecretsManager _secretsManager;

    public AwsSecretsManager(IAmazonSecretsManager secretsManager)
    {
        _secretsManager = secretsManager;
    }
    
    public async Task<string> GetSecretValueAsync(string secretName)
    {
        try
        {
            var request = new GetSecretValueRequest
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
}