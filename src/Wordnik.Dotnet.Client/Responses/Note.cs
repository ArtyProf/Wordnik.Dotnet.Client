using Newtonsoft.Json;

namespace Wordnik.Dotnet.Client.Models
{
    /// <summary>
    /// Represents an annotation or note added to the definition.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// The type of note (e.g., editorial, linguistic).
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// Text content of the note.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }
    }
}