using Newtonsoft.Json;

namespace Wordnik.Client.Responses
{
    /// <summary>
    /// Represents a citation source for a word definition.
    /// </summary>
    public class Citation
    {
        /// <summary>
        /// The text of the cited material for the definition.
        /// </summary>
        [JsonProperty("cite")]
        public string Cite { get; set; }

        /// <summary>
        /// The source of the cited material (e.g., book, dictionary, article).
        /// </summary>
        [JsonProperty("source")]
        public string Source { get; set; }
    }
}