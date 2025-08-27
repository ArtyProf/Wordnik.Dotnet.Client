using Newtonsoft.Json;

namespace Wordnik.Dotnet.Client.Models
{
    /// <summary>
    /// Represents phonetic or pronunciation details for a word.
    /// </summary>
    public class TextPronunciation
    {
        /// <summary>
        /// The raw pronunciation text.
        /// </summary>
        [JsonProperty("raw")]
        public string Raw { get; set; }

        /// <summary>
        /// The type of pronunciation text (e.g., IPA, phonetic).
        /// </summary>
        [JsonProperty("rawType")]
        public string RawType { get; set; }
    }
}