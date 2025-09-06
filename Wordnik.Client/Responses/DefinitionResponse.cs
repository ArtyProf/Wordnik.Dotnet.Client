using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wordnik.Client.Responses
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
        /// URL to the wordnik source for the definition.
        /// </summary>
        [JsonProperty("wordnikUrl")]
        public string WordnikUrl { get; set; }

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
        public string       SourceDictionary { get; set; }

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