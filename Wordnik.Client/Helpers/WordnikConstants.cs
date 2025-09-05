using System;

namespace Wordnik.Client.Helpers
{
    /// <summary>
    /// A static class containing constants used throughout the Wordnik API client.
    /// </summary>
    public static class WordnikConstants
    {
        /// <summary>
        /// The base URL for the Wordnik API.
        /// </summary>
        public static string WordnikApiUrl => Environment.GetEnvironmentVariable("WordnikApiUrl") ?? "https://api.wordnik.com/v4/";

        /// <summary>
        /// The header name for the Wordnik API key.
        /// </summary>
        public const string WordnikApiKeyName = "api_key";
    }
}
