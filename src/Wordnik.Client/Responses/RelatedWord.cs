using System.Collections.Generic;
using Newtonsoft.Json;

namespace Wordnik.Client.Responses
{
    /// <summary>
    /// Represents related words, such as synonyms or antonyms, associated with a word's definition.
    /// </summary>
    public class RelatedWord
    {
        /// <summary>
        /// The type of relationship (e.g., synonym, antonym).
        /// </summary>
        [JsonProperty("relationshipType")]
        public string RelationshipType { get; set; }

        /// <summary>
        /// A list of words that are connected via the specified relationship type.
        /// </summary>
        [JsonProperty("words")]
        public List<string> Words { get; set; }
    }
}