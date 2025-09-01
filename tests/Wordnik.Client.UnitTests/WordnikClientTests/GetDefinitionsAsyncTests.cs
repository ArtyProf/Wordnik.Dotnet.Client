using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Wordnik.Client.Helpers;
using Wordnik.Client.Requests;
using Wordnik.Client.Responses;

namespace Wordnik.Client.UnitTests.WordnikClientTests
{
    public class GetDefinitionsAsyncTests
    {
        [Fact]
        public async Task GetDefinitionsAsync_ShouldConstructCorrectUrlAndReturnData()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            var responseContent = JsonConvert.SerializeObject(new List<DefinitionResponse>
            {
                new() { Text = "A representative form or pattern." }
            });

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = new StringContent(responseContent)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
            };

            var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

            var request = new GetDefinitionsRequest
            {
                Word = "example",
                Limit = 1
            };

            // Act
            var result = await wordnikClient.GetDefinitionsAsync(request);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal("A representative form or pattern.", result.First().Text);
            mockHttpMessageHandler.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(
                    req =>
                        req.Method == HttpMethod.Get &&
                        req.RequestUri!.AbsoluteUri ==
                        $"{WordnikConstants.WordnikApiUrl}word.json/example/definitions?limit=1&includeRelated=false&useCanonical=false&includeTags=false"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }
    }
}