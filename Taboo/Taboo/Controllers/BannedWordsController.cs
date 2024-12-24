using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.BannedWords;
using Taboo.DTOs.Words;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannedWordsController(IBannedWordService _service) : ControllerBase
    {
        
        [HttpGet]

        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
                await _service.DeleteBannedWordAsync(id);
                return Ok();
            
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            
                var word = await _service.GetBannedWordByIdAsync(id);
                return Ok(word);
            
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, BannedWordUpdateDto dto)
        {
            
                await _service.UpdateAsync(id, dto);
                return Ok();
            
        }
    }
}
