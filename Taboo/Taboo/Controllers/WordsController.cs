using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Words;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController(IWordsService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(WordCreateDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok();
        }
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }
    }
}
