using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Games;
using Taboo.Exceptions;
using Taboo.ExternalServices.Abstracts;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GamesController(IGamesService _service, ICacheService _cache) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(GameCreateDto dto)
    {
        return Ok(await _service.AddAsync(dto));
    }

    [HttpPost("[action]/{id}")]

    public async Task<IActionResult> Start(Guid id)
    {
            
            return Ok(await _service.StartAsync(id));
    }
    [HttpPost("[action]/{id}")]
    public async Task<IActionResult> Success(Guid id)
    {
        
        return Ok(await _service.SuccesAsync(id));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> Status(Guid id)
    {
        
            return Ok(await _service.GetCurrentStatus(id));
        
    }


    [HttpGet("[action]")]
    public async Task<IActionResult> Get(string key)
    {
        return Ok(await _cache.GetAsync<string>(key));
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Set(string key,string value)
    {
        await _cache.SetAsync(key, value);
        return Ok();
    }
}
