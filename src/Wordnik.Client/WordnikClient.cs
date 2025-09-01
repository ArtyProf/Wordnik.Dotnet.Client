using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Wordnik.Client.Helpers;
using Wordnik.Client.Requests;
using Wordnik.Client.Responses;

namespace Wordnik.Client
{
    public class WordnikClient : IWordnikClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="WordnikClient"/> class.
        /// Use this constructor for Dependency Injection (DI).
        /// </summary>
        /// <param name="httpClient">An instance of HttpClient provided by Dependency Injection.</param>
        /// <param name="apiKey">Your Wordnik API key.</param>
        public WordnikClient(HttpClient httpClient, string apiKey)
        {  
            _httpClient = httpClient;

            _httpClient.BaseAddress ??= new Uri(WordnikConstants.WordnikApiUrl);
            if (!_httpClient.DefaultRequestHeaders.Contains(WordnikConstants.WordnikApiKeyName))
            {
                if (string.IsNullOrWhiteSpace(apiKey))
                {
                    throw new ArgumentException("API key cannot be null or empty.", nameof(apiKey));
                }

                _httpClient.DefaultRequestHeaders.Add(WordnikConstants.WordnikApiKeyName, apiKey);
            }
        }

        /// <inheritdoc />
        public async Task<IEnumerable<DefinitionResponse>> GetDefinitionsAsync(GetDefinitionsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (string.IsNullOrWhiteSpace(request.Word))
            {
                throw new ArgumentException("Word cannot be null or empty.", nameof(request.Word));
            }

            var url = $"word.json/{Uri.EscapeDataString(request.Word)}/definitions?{request}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {response.ReasonPhrase}");
            }

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<IEnumerable<DefinitionResponse>>(json);
        }
    }
}
