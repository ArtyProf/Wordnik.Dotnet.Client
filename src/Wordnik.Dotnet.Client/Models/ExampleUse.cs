using Newtonsoft.Json;

namespace Wordnik.Dotnet.Client.Models
{
    /// <summary>
    /// Represents an example usage of a word in context.
    /// </summary>
    public class ExampleUse
    {
        /// <summary>
        /// Example sentence or text demonstrating usage of the word.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}