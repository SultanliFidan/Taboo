using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }
}
