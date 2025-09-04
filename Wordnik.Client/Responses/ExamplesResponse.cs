using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wordnik.Client.Responses
{
    /// <summary>
    /// Represents the response model for the "examples" endpoint of the Wordnik API.
    /// </summary>
    public class ExamplesResponse
    {
        /// <summary>
        /// A list of example sentences or usages for a given word.
        /// </summary>
        [JsonProperty("examples")]
        public List<Example> Examples { get; set; }
    }

    /// <summary>
    /// Represents an individual example usage of a word.
    /// </summary>
    public class Example
    {
        /// <summary>
        /// The provider associated with the example.
        /// </summary>
        [JsonProperty("provider")]
        public Provider Provider { get; set; }

        /// <summary>
        /// The year the example was written or published.
        /// </summary>
        [JsonProperty("year")]
        public int? Year { get; set; }

        /// <summary>
        /// The rating of the example (a measure of quality or relevance).
        /// </summary>
        [JsonProperty("rating")]
        public double Rating { get; set; }

        /// <summary>
        /// The URL where the example is located, if applicable.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// The word associated with this example.
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; }

        /// <summary>
        /// The actual text of the example.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// The ID of the document this example belongs to.
        /// </summary>
        [JsonProperty("documentId")]
        public int DocumentId { get; set; }

        /// <summary>
        /// The unique ID of the example.
        /// </summary>
        [JsonProperty("exampleId")]
        public long ExampleId { get; set; }

        /// <summary>
        /// The title of the document or source where the example was found.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// The author of the document or text where the example was found.
        /// </summary>
        [JsonProperty("author")]
        public string Author { get; set; }
    }

    /// <summary>
    /// Represents a provider of example text or data in the Wordnik API.
    /// </summary>
    public class Provider
    {
        /// <summary>
        /// The unique ID of the provider.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }
    }
}
