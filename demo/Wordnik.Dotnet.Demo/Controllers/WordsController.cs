using Microsoft.AspNetCore.Mvc;
using Wordnik.Dotnet.Client;
using Wordnik.Dotnet.Client.Models;
using Wordnik.Dotnet.Client.Requests;

namespace Wordnik.Dotnet.Demo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WordsController : ControllerBase
{
    private readonly IWordnikClient _wordnikClient;

    public WordsController(IWordnikClient wordnikClient)
    {
        _wordnikClient = wordnikClient ?? throw new ArgumentNullException(nameof(wordnikClient));
    }

    [HttpGet("definitions")]
    public async Task<ActionResult<IEnumerable<DefinitionResponse>>> GetDefinitions(GetDefinitionsRequest request)
    {
        if (request == null)
        {
            return BadRequest("The request is required.");
        }

        try
        {
            var definitions = await _wordnikClient.GetDefinitionsAsync(request);

            return Ok(definitions);
        }
        catch (HttpRequestException ex)
        {
            return StatusCode(500, $"Error communicating with Wordnik API: {ex.Message}");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An unexpected error occurred: {ex.Message}");
        }
    }
}