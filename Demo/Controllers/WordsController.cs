using Microsoft.AspNetCore.Mvc;
using Wordnik.Client;
using Wordnik.Client.Requests;
using Wordnik.Client.Responses;

namespace Wordnik.Demo.Controllers;

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
    public async Task<ActionResult<IEnumerable<DefinitionResponse>>> GetDefinitions([FromQuery] GetDefinitionsRequest request)
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