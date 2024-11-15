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
    #region Test Methods (GetSecret)

    [Fact]
    public async Task GetSecret_SecretValueIsValidJson_ReturnsDeserialized()
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

        testOutputHelper.WriteLine(secret.Username);
        testOutputHelper.WriteLine(secret.Password);

        mockSecretsManager.Verify(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default), Times.Once);
    }

    [Fact]
    public async Task GetSecret_SecretValueIsInvalidJson_ThrowsException()
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

        mockSecretsManager.Verify(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default), Times.Once);
    }

    [Fact]
    public async Task GetSecret_SecretValueReturnsEmptyString_ThrowsException()
    {
        Mock<IAmazonSecretsManager> mockSecretsManager = new();
        string emptyJson = string.Empty;
        GetSecretValueResponse response = new()
        {
            SecretString = emptyJson
        };

        mockSecretsManager
            .Setup(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default))
            .ReturnsAsync(response);

        AwsSecretsManager awsSecretsManager = new(mockSecretsManager.Object);

        await Assert.ThrowsAsync<JsonException>(async () =>
            await awsSecretsManager.GetSecret<Secret>("TEST_SECRET"));

        mockSecretsManager.Verify(x => x.GetSecretValueAsync(It.IsAny<GetSecretValueRequest>(), default), Times.Once);
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