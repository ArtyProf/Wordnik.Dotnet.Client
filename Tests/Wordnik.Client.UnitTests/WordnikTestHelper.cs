using Moq;
using Moq.Protected;
using System.Net;
using Wordnik.Client.Helpers;

namespace Wordnik.Client.UnitTests;

public static class WordnikTestHelper
{
    /// <summary>
    /// Runs a generic test for Wordnik client methods.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    /// <typeparam name="TResponse">The type of the response object.</typeparam>
    /// <param name="mockResponseContent">The mocked response content in JSON.</param>
    /// <param name="expectedUrl">The expected URL for the API method invocation.</param>
    /// <param name="apiMethod">A delegate representing the API method to be tested.</param>
    /// <param name="request">The request object to pass to the API method.</param>
    /// <param name="assertions">A callback for performing custom assertions on the response.</param>
    /// <returns>A task representing the async test operation.</returns>
    public static async Task RunGenericApiMethodTest<TRequest, TResponse>(
        string mockResponseContent,
        string expectedUrl,
        Func<WordnikClient, TRequest, Task<TResponse>> apiMethod,
        TRequest request,
        Action<TResponse> assertions = null)
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(mockResponseContent)
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
        };

        var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

        // Act
        var response = await apiMethod(wordnikClient, request);

        // Assert
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(
                req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.AbsoluteUri == expectedUrl
            ),
            ItExpr.IsAny<CancellationToken>());
        assertions?.Invoke(response);
    }

    /// <summary>
    /// Runs a test to verify exception propagation when the mocked response indicates failure.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    /// <param name="expectedUrl">The expected URL for the API method invocation.</param>
    /// <param name="apiMethod">A delegate representing the API method to be tested.</param>
    /// <param name="request">The request object to pass to the API method.</param>
    public static async Task RunHttpFailureTest<TRequest>(
        HttpStatusCode statusCode,
        string reasonPhrase,
        string expectedUrl,
        Func<WordnikClient, TRequest, Task> apiMethod,
        TRequest request)
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();

        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = statusCode,
                ReasonPhrase = reasonPhrase
            });

        var httpClient = new HttpClient(mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
        };

        var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

        // Act & Assert
        var exception = await Assert.ThrowsAsync<HttpRequestException>(() => apiMethod(wordnikClient, request));
        Assert.Contains($"Request failed with status code {statusCode}", exception.Message);
        mockHttpMessageHandler.Protected().Verify(
            "SendAsync",
            Times.Once(),
            ItExpr.Is<HttpRequestMessage>(
                req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.AbsoluteUri == expectedUrl
            ),
            ItExpr.IsAny<CancellationToken>());
    }

    /// <summary>
    /// Runs a test to ensure <see cref="ArgumentNullException"/> is thrown when a null request is provided.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    /// <param name="apiMethod">The API method being tested.</param>
    /// <param name="expectedParamName">The expected name of the parameter causing the exception.</param>
    public static async Task RunNullRequestTest<TRequest>(
        Func<WordnikClient, TRequest, Task> apiMethod,
        string expectedParamName)
    {
        // Arrange
        var httpClient = new HttpClient();
        var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => apiMethod(wordnikClient, default!));
        Assert.Equal(expectedParamName, exception.ParamName);
    }

    /// <summary>
    /// Runs a test to ensure <see cref="ArgumentException"/> is thrown for invalid request parameters like empty or null Word values.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    /// <param name="apiMethod">The API method being tested.</param>
    /// <param name="request">The request object to test.</param>
    /// <param name="expectedParamName">The expected name of the parameter causing the exception.</param>
    /// <param name="expectedExceptionMessagePart">A part of the expected exception message to verify.</param>
    public static async Task RunInvalidWordValidationTest<TRequest>(
        Func<WordnikClient, TRequest, Task> apiMethod,
        TRequest request,
        string expectedExceptionMessagePart)
    {
        // Arrange
        var httpClient = new HttpClient();
        var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

        // Act & Assert
        var exception = await Assert.ThrowsAsync<ArgumentException>(() => apiMethod(wordnikClient, request));

        Assert.Equal(nameof(request), exception.ParamName);
        Assert.Contains(expectedExceptionMessagePart, exception.Message);
    }

    /// <summary>
    /// Runs a test where a malformed JSON response is expected to cause a deserialization exception.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    /// <typeparam name="TException">The type of exception expected to be thrown during deserialization.</typeparam>
    /// <param name="malformedJson">The malformed JSON string to simulate in the response.</param>
    /// <param name="apiMethod">The API method to invoke.</param>
    /// <param name="request">The request object to invoke the API method with.</param>
    /// <param name="expectedExceptionMessagePart">A part of the exception message to verify (optional).</param>
    public static async Task RunMalformedJsonTest<TRequest, TException>(
        string malformedJson,
        Func<WordnikClient, TRequest, Task> apiMethod,
        TRequest request,
        string expectedExceptionMessagePart = null)
        where TException : Exception
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
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

        // Act & Assert
        var exception = await Assert.ThrowsAsync<TException>(() => apiMethod(wordnikClient, request));
        if (!string.IsNullOrWhiteSpace(expectedExceptionMessagePart))
        {
            Assert.Contains(expectedExceptionMessagePart, exception.Message, StringComparison.OrdinalIgnoreCase);
        }
    }

    /// <summary>
    /// Runs a test to verify exception propagation from a directly thrown HttpClient exception.
    /// </summary>
    /// <typeparam name="TRequest">The type of the request object.</typeparam>
    /// <typeparam name="TException">The type of exception expected to propagate.</typeparam>
    /// <param name="exceptionToThrow">The exception to simulate being thrown by HttpClient.</param>
    /// <param name="apiMethod">The API method to invoke.</param>
    /// <param name="request">The request object to invoke the API method with.</param>
    /// <param name="expectedMessage">The expected exception message (optional).</param>
    public static async Task RunHttpClientExceptionPropagationTest<TRequest, TException>(
        Exception exceptionToThrow,
        Func<WordnikClient, TRequest, Task> apiMethod,
        TRequest request,
        string expectedMessage = null)
        where TException : Exception
    {
        // Arrange
        var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
        mockHttpMessageHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(exceptionToThrow);

        var httpClient = new HttpClient(mockHttpMessageHandler.Object)
        {
            BaseAddress = new Uri(WordnikConstants.WordnikApiUrl)
        };

        var wordnikClient = new WordnikClient(httpClient, "fake_api_key");

        // Act & Assert
        var exception = await Assert.ThrowsAsync<TException>(() => apiMethod(wordnikClient, request));
        if (!string.IsNullOrWhiteSpace(expectedMessage))
        {
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
