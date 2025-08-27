using System;
using System.Collections.Generic;
using System.Linq;
using Wordnik.Dotnet.Client.Enums;
using Wordnik.Dotnet.Client.Helpers;

namespace Wordnik.Dotnet.Client.Requests
{
    /// <summary>
    /// Request model for retrieving definitions from the Wordnik API.
    /// </summary>
    public class GetDefinitionsRequest
    {
        /// <summary>
        /// The word to retrieve definitions for.
        /// This is a required parameter.
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// The maximum number of definitions to retrieve.
        /// </summary>
        public int Limit { get; set; } = 200;

        /// <summary>
        /// A CSV list of part-of-speech types (e.g., "noun", "verb").
        /// </summary>
        public List<PartOfSpeechType> PartOfSpeech { get; set; } = new List<PartOfSpeechType>();

        /// <summary>
        /// Whether to include related words with definitions.
        /// Default value is false.
        /// </summary>
        public bool IncludeRelated { get; set; } = false;

        /// <summary>
        /// The source dictionaries to limit the response to.
        /// Default is empty, meaning all available dictionaries are searched.
        /// </summary>
        public List<SourceDictionariesType> SourceDictionaries { get; set; } = new List<SourceDictionariesType>();

        /// <summary>
        /// Whether to return the canonical (root) form of the word.
        /// For example, "cats" -> "cat".
        /// Default value is false.
        /// </summary>
        public bool UseCanonical { get; set; } = false;

        /// <summary>
        /// Whether to return a closed set of XML tags in the response.
        /// Default value is false.
        /// </summary>
        public bool IncludeTags { get; set; } = false;

        /// <summary>
        /// Constructs the query string representation of all parameters for this request.
        /// </summary>
        public override string ToString()
        {
            var queryParameters = new List<string>();

            if (Limit > 0)
            {
                queryParameters.Add($"limit={Limit}");
            }

            if (PartOfSpeech != null && PartOfSpeech.Any())
            {
                var partsOfSpeech = PartOfSpeech
                    .Select(pos => pos.ToApiString());
                queryParameters.Add($"partOfSpeech={string.Join(",", partsOfSpeech)}");
            }

            queryParameters.Add($"includeRelated={IncludeRelated.ToString().ToLower()}");

            if (SourceDictionaries != null && SourceDictionaries.Any())
            {
                var sources = SourceDictionaries
                    .Select(source => source.ToApiString());
                queryParameters.Add($"sourceDictionaries={string.Join(",", sources)}");
            }

            queryParameters.Add($"useCanonical={UseCanonical.ToString().ToLower()}");

            queryParameters.Add($"includeTags={IncludeTags.ToString().ToLower()}");

            return string.Join("&", queryParameters);
        }
    }
}