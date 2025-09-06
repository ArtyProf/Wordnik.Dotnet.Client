using System;
using System.Collections.Generic;

namespace Wordnik.Client.Requests
{
    /// <summary>
    /// Represents the request model for the Wordnik frequency API.
    /// Contains parameters required to fetch word frequency data.
    /// </summary>
    public class GetFrequencyRequest : IWord
    {
        /// <summary>
        /// The word for which frequency data is requested.
        /// </summary>
        /// <example>ball</example>
        public string Word { get; set; }

        /// <summary>
        /// If true, include duplicate examples from different sources.
        /// If false, removes duplicates.
        /// Default is false.
        /// </summary>
        /// <example>false</example>
        public bool IncludeDuplicates { get; set; } = false;

        /// <summary>
        /// If true, fetches the canonical form of the word (e.g., "cats" -> "cat").
        /// If false, fetches the exact word requested.
        /// Default is false.
        /// </summary>
        /// <example>false</example>
        public bool UseCanonical { get; set; } = false;

        /// <summary>
        /// The number of results to skip from the start.
        /// Useful for pagination.
        /// Default is 0.
        /// </summary>
        /// <example>0</example>
        public int Skip { get; set; } = 0;

        /// <summary>
        /// The maximum number of results to return.
        /// Default is 5.
        /// </summary>
        /// <example>5</example>
        public int Limit { get; set; } = 5;

        /// <summary>
        /// Constructs a query string from the request parameters.
        /// </summary>
        /// <returns>A query string to append to the API request URL.</returns>
        public override string ToString()
        {
            var queryParams = new List<string>();

            if (!string.IsNullOrWhiteSpace(Word))
            {
                queryParams.Add($"word={Uri.EscapeDataString(Word)}");
            }

            if (IncludeDuplicates)
            {
                queryParams.Add($"includeDuplicates={IncludeDuplicates.ToString()}");
            }

            if (UseCanonical)
            {
                queryParams.Add($"useCanonical={UseCanonical.ToString()}");
            }

            if (Skip > 0)
            {
                queryParams.Add($"skip={Skip}");
            }

            if (Limit > 0)
            {
                queryParams.Add($"limit={Limit}");
            }

            return string.Join("&", queryParams);
        }
    }
}
