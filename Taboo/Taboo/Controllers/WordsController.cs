using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Exceptions;
using Taboo.Services.Abstracts;

namespace Taboo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordsController(IWordsService _service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(WordCreateDto dto)
    {
        
            await _service.CreateAsync(dto);
            return Created();
        
    }
    [HttpGet]

    public async Task<IActionResult> Get()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        
            await _service.DeleteWordAsync(id);
            return Ok();
        
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        
            var word = await _service.GetWordByIdAsync(id);
            return Ok(word);
       
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, WordUpdateDto dto)
    {
        
            await _service.UpdateAsync(id, dto);
            return Ok();
        

    }


}
