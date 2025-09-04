using Microsoft.Extensions.Configuration;
using Wordnik.Client.Helpers;
using Wordnik.Client.Requests;

namespace Wordnik.Client.IntegrationTests;

public class DefinitionsIntegrationTests
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public DefinitionsIntegrationTests()
    {
        _configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

        _apiKey = _configuration["Wordnik:ApiKey"]
                  ?? throw new InvalidOperationException("API Key is missing from appsettings.json.");

        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
        };
    }

    [Theory]
    [InlineData("example", 3)] // Word: "example", Limit: 3 results
    public async Task GetDefinitions_WhenCalled_ShouldReturnDefinitions(string word, int limit)
    {
        // Arrange
        var client = new WordnikClient(_httpClient, _apiKey);

        var request = new GetDefinitionsRequest
        {
            Word = word,
            Limit = limit
        };

        // Act
        var definitions = await client.GetDefinitionsAsync(request);

        // Assert
        Assert.NotNull(definitions);
        Assert.NotEmpty(definitions);
        Assert.True(definitions.Count() == limit);

        foreach (var definition in definitions)
        {
            Assert.False(string.IsNullOrWhiteSpace(definition.Text), "Definition text is missing.");
            Assert.NotNull(definition.PartOfSpeech);
            Assert.NotNull(definition.Word);
            Assert.NotNull(definition.WordnikUrl);
        }
    }
}
