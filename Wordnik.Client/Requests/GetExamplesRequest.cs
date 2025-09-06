using System;
using System.Collections.Generic;

namespace Wordnik.Client.Requests
{
    /// <summary>
    /// Represents the request parameters for the Wordnik API examples endpoint.
    /// </summary>
    public class GetExamplesRequest : IWord
    {
        /// <summary>
        /// Gets or sets the word to return examples for. This is a required parameter.
        /// </summary>
        public string Word { get; set; }

        /// <summary>
        /// Gets or sets whether to include duplicate examples from different sources.
        /// This is an optional parameter. Defaults to <c>false</c>.
        /// </summary>
        public bool IncludeDuplicates { get; set; } = false;

        /// <summary>
        /// Gets or sets whether to use the canonical form of the word (e.g., transform 'cats' to 'cat').
        /// This is an optional parameter. Defaults to <c>false</c>.
        /// </summary>
        public bool UseCanonical { get; set; } = false;

        /// <summary>
        /// Gets or sets the number of results to skip in the response.
        /// This is an optional parameter. Defaults to <c>0</c>.
        /// </summary>
        public int? Skip { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of results to return.
        /// This is an optional parameter. Defaults to <c>5</c>.
        /// </summary>
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
                queryParams.Add($"includeDuplicates={IncludeDuplicates}");
            }

            if (UseCanonical)
            {
                queryParams.Add($"useCanonical={UseCanonical}");
            }

            if (Skip.HasValue)
            {
                queryParams.Add($"skip={Skip.Value}");
            }

            if (Limit > 0)
            {
                queryParams.Add($"limit={Limit}");
            }

            return string.Join("&", queryParams);
        }
    }
}
