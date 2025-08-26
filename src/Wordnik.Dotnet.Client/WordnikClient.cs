using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Wordnik.Dotnet.Client.Models;

namespace Wordnik.Dotnet.Client
{
    public class WordnikClient : IWordnikClient
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        private const string BaseUrl = "https://api.wordnik.com/v4";

        /// <summary>
        /// Initializes a new instance of the <see cref="WordnikClient"/> class.
        /// Use this constructor for Dependency Injection (DI).
        /// </summary>
        /// <param name="httpClient">An instance of HttpClient provided by Dependency Injection.</param>
        /// <param name="apiKey">Your Wordnik API key.</param>
        public WordnikClient(HttpClient httpClient, string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentException("API key cannot be null or empty.", nameof(apiKey));
            }
                
            _apiKey = apiKey;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));

            _httpClient.BaseAddress ??= new Uri(BaseUrl);
            _httpClient.DefaultRequestHeaders.Add("api_key", apiKey);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<DefinitionResponse>> GetDefinitionsAsync(string word, int limit = 10)
        {
            var url = $"/word.json/{word}/definitions?limit={limit}";

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
