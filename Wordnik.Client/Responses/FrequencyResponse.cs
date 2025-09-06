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
        public List<FrequencyYear> Frequency { get; set; }

        /// <summary>
        /// Total count of word occurrences across all years.
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// The word for which frequencies were fetched.
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// Frequency count for unknown years, where the year is not explicitly specified.
        /// </summary>
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
        public string Year { get; set; }

        /// <summary>
        /// The number of word occurrences in the specified year.
        /// </summary>
        public int Count { get; set; }
    }
}
