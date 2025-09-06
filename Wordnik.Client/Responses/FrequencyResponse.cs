using Newtonsoft.Json;
using System.Collections.Generic;

namespace Wordnik.Client.Responses
{
    /// <summary>
    /// Represents the response model for the Wordnik frequency API.
    /// Contains word usage frequency details across years.
    /// </summary>
    public class FrequencyResponse
    {
        /// <summary>
        /// List of usage frequencies broken down by year.
        /// </summary>
        [JsonProperty("frequency")]
        public List<FrequencyYear> FrequenciesByYears { get; set; }

        /// <summary>
        /// Total count of word occurrences across all years.
        /// </summary>
        [JsonProperty("totalCount")]
        public int TotalCount { get; set; }

        /// <summary>
        /// The word for which frequencies were fetched.
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; }

        /// <summary>
        /// Frequency count for unknown years, where the year is not explicitly specified.
        /// </summary>
        [JsonProperty("unknownYearCount")]
        public int UnknownYearCount { get; set; }
    }

    /// <summary>
    /// Represents the frequency data for a specific year.
    /// </summary>
    public class FrequencyYear
    {
        /// <summary>
        /// The specific year for the frequency data.
        /// </summary>
        [JsonProperty("year")]
        public string Year { get; set; }

        /// <summary>
        /// The number of word occurrences in the specified year.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}