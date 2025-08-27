using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wordnik.Dotnet.Client.Models
{
    /// <summary>
    /// Represents a word definition object returned by the Wordnik API.
    /// </summary>
    public class DefinitionResponse
    {
        /// <summary>
        /// Text attribution (e.g., source) for the definition.
        /// </summary>
        [JsonProperty("attributionText")]
        public string AttributionText { get; set; }

        /// <summary>
        /// URL to the attribution source for the definition.
        /// </summary>
        [JsonProperty("attributionUrl")]
        public string AttributionUrl { get; set; }

        /// <summary>
        /// List of citation sources for the word definition.
        /// </summary>
        [JsonProperty("citations")]
        public List<Citation> Citations { get; set; }

        /// <summary>
        /// Example uses of the word related to the definition.
        /// </summary>
        [JsonProperty("exampleUses")]
        public List<ExampleUse> ExampleUses { get; set; }

        /// <summary>
        /// Extended explanation or alternative version of the definition text.
        /// </summary>
        [JsonProperty("extendedText")]
        public string ExtendedText { get; set; }

        /// <summary>
        /// Labels describing the usage (e.g., region, domain).
        /// </summary>
        [JsonProperty("labels")]
        public List<Label> Labels { get; set; }

        /// <summary>
        /// Notes or comments relevant to the definition.
        /// </summary>
        [JsonProperty("notes")]
        public List<Note> Notes { get; set; }

        /// <summary>
        /// The grammatical part of speech for the word (e.g., noun, verb).
        /// </summary>
        [JsonProperty("partOfSpeech")]
        public string PartOfSpeech { get; set; }

        /// <summary>
        /// List of related words, such as synonyms or antonyms, relevant to the definition.
        /// </summary>
        [JsonProperty("relatedWords")]
        public List<RelatedWord> RelatedWords { get; set; }

        /// <summary>
        /// A numeric score or confidence for the relevance of the definition.
        /// </summary>
        [JsonProperty("score")]
        public double Score { get; set; }

        /// <summary>
        /// Sequence identifier as a string (used for ordering definitions).
        /// </summary>
        [JsonProperty("seqString")]
        public string SeqString { get; set; }

        /// <summary>
        /// Sequence identifier (used for ordering definitions).
        /// </summary>
        [JsonProperty("sequence")]
        public string Sequence { get; set; }

        /// <summary>
        /// The name of the source dictionary (e.g., WordNet, Wiktionary).
        /// </summary>
        [JsonProperty("sourceDictionary")]
        public string SourceDictionary { get; set; }

        /// <summary>
        /// The core textual definition of the word.
        /// </summary>
        [JsonProperty("text")]
        public string Text { get; set; }

        /// <summary>
        /// Phonetic or pronunciation details related to the word.
        /// </summary>
        [JsonProperty("textProns")]
        public List<TextPronunciation> TextProns { get; set; }

        /// <summary>
        /// The word being defined.
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; }
    }
}