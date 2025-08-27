using Newtonsoft.Json;

namespace Wordnik.Dotnet.Client.Models
{
    /// <summary>
    /// Represents additional labeling information such as domain, region, or usage.
    /// </summary>
    public class Label
    {
        /// <summary>
        /// The type of the label (e.g., domain, region).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The specific value for the label.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}