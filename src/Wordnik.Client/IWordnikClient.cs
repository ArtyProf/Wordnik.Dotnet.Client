using System.Collections.Generic;
using System.Threading.Tasks;
using Wordnik.Client.Requests;
using Wordnik.Client.Responses;

namespace Wordnik.Client
{
    public interface IWordnikClient
    {
        /// <summary>
        /// Fetches definitions of a word from Wordnik API.
        /// </summary>
        /// <param name="request">Request model for retrieving definitions from the Wordnik API.</param>
        /// <returns>A list of definitions.</returns>
        Task<IEnumerable<DefinitionResponse>> GetDefinitionsAsync(GetDefinitionsRequest request);
    }
}
