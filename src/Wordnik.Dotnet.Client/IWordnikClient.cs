using System.Collections.Generic;
using System.Threading.Tasks;
using Wordnik.Dotnet.Client.Models;

namespace Wordnik.Dotnet.Client
{
    public interface IWordnikClient
    {
        /// <summary>
        /// Fetches definitions of a word from Wordnik API.
        /// </summary>
        /// <param name="word">The word to look up.</param>
        /// <param name="limit">The maximum number of definitions to retrieve.</param>
        /// <returns>A list of definitions.</returns>
        Task<IEnumerable<DefinitionResponse>> GetDefinitionsAsync(string word, int limit = 10);
    }
}
