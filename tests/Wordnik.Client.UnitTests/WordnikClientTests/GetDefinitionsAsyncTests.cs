using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;
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
                        $"{WordnikConstants.WordnikApiUrl}word.json/example/definitions?{request}"
                ),
                ItExpr.IsAny<CancellationToken>()
            );
        }

        [Fact]
        public async Task GetDefinitionsAsync_RequestIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange
            var httpClient = new HttpClient();
            var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => wordnikClient.GetDefinitionsAsync(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetDefinitionsAsync_RequestWordIsInvalid_ShouldThrowArgumentException(string word)
        {
            // Arrange
            var httpClient = new HttpClient();
            var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

            var request = new GetDefinitionsRequest
            {
                Word = word
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => wordnikClient.GetDefinitionsAsync(request));

            Assert.Equal("Word", exception.ParamName);
            Assert.Contains("Word cannot be null or empty.", exception.Message);
        }

        [Fact]
        public async Task GetDefinitionsAsync_HttpResponseIsNotSuccess_ShouldThrowHttpRequestException()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    ReasonPhrase = "Bad Request"
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
            };

            var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

            var request = new GetDefinitionsRequest
            {
                Word = "example"
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<HttpRequestException>(() => wordnikClient.GetDefinitionsAsync(request));

            Assert.Contains("Request failed with status code BadRequest", exception.Message);
        }

        [Fact]
        public async Task GetDefinitionsAsync_InvalidJsonResponse_ShouldThrowJsonSerializationException()
        {
            // Arrange
            var malformedJson = "{ invalid json }";

            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(malformedJson)
                });

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
            };

            var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

            var request = new GetDefinitionsRequest
            {
                Word = "example"
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<JsonReaderException>(() => wordnikClient.GetDefinitionsAsync(request));

            Assert.Contains("Invalid character after parsing property", exception.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public async Task GetDefinitionsAsync_HttpClientThrowsException_ShouldPropagateException()
        {
            // Arrange
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ThrowsAsync(new InvalidOperationException("A test exception during HTTP processing"));

            var httpClient = new HttpClient(mockHttpMessageHandler.Object)
            {
                BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
            };

            var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

            var request = new GetDefinitionsRequest
            {
                Word = "example"
            };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => wordnikClient.GetDefinitionsAsync(request));

            Assert.Equal("A test exception during HTTP processing", exception.Message);
        }
    }
}