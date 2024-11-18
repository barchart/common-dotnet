#region Using Statements

using System.Text.Json;
using System.Text.Json.Serialization;

using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

using Barchart.Common.Aws;

#endregion

namespace Barchart.Common.Tests.Aws;

public class AwsSecretsManagerTests(ITestOutputHelper testOutputHelper)
{
    #region Test Methods (GetSecret<T>)
    
    [Fact]
    public async Task GetSecret_SecretValueTypedValidJson_ReturnsDeserialized()
    {
        Mock<IAmazonSecretsManager> mockSecretsManager = new Mock<IAmazonSecretsManager>();
        string secretJson = "{\"username\":\"luka\",\"password\":\"mock\"}";
        GetSecretValueResponse response = new()
        {
            SecretString = secretJson
        };

        mockSecretsManager
            .Setup(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default))
            .ReturnsAsync(response);

        AwsSecretsManager awsSecretsManager = new(mockSecretsManager.Object);

        Secret secret = await awsSecretsManager.GetSecret<Secret>("TEST_SECRET");

        Assert.NotNull(secret);
        Assert.Equal("luka", secret.Username);
        Assert.Equal("mock", secret.Password);
    }
    
    [Fact]
    public async Task GetSecret_SecretValueTypedInvalidJson_ThrowsException()
    {
        Mock<IAmazonSecretsManager> mockSecretsManager = new();
        string invalidJson = "invalid-json-format";
        GetSecretValueResponse response = new()
        {
            SecretString = invalidJson
        };

        mockSecretsManager
            .Setup(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default))
            .ReturnsAsync(response);

        AwsSecretsManager awsSecretsManager = new(mockSecretsManager.Object);

        await Assert.ThrowsAsync<JsonException>(async () =>
            await awsSecretsManager.GetSecret<Secret>("TEST_SECRET"));
    }
    
    [Fact]
    public async Task GetSecret_SecretValueTypedSecretEmptyString_ThrowsException()
    {
        Mock<IAmazonSecretsManager> mockSecretsManager = new();
        GetSecretValueResponse response = new()
        {
            SecretString = string.Empty
        };

        mockSecretsManager
            .Setup(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default))
            .ReturnsAsync(response);

        AwsSecretsManager awsSecretsManager = new(mockSecretsManager.Object);

        await Assert.ThrowsAsync<JsonException>(async () =>
            await awsSecretsManager.GetSecret<Secret>("TEST_SECRET"));
    }
    
    #endregion

    #region Test Methods (GetSecret)
    
    [Fact]
    public async Task GetSecret_SecretValue_ReturnsString()
    {
        Mock<IAmazonSecretsManager> mockSecretsManager = new Mock<IAmazonSecretsManager>();
        string secretJson = "{\"username\":\"luka\",\"password\":\"mock\"}";
        GetSecretValueResponse response = new()
        {
            SecretString = secretJson
        };

        mockSecretsManager
            .Setup(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default))
            .ReturnsAsync(response);

        AwsSecretsManager awsSecretsManager = new(mockSecretsManager.Object);

        string secretString = await awsSecretsManager.GetSecret("TEST_SECRET");

        Assert.NotNull(secretString);
        Assert.Equal(secretJson, secretString);
    }

    #endregion
    
    #region Nested Types

    private class Secret(string username, string password)
    {
        [JsonPropertyName("username")]
        public string Username { get; } = username;

        [JsonPropertyName("password")]
        public string Password { get; } = password;
    }

    #endregion
}