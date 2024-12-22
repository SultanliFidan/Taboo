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
        try
        {
            await _service.CreateAsync(dto);
            return Created();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {

                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
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
        try
        {
            await _service.DeleteWordAsync(id);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {

                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var word = await _service.GetWordByIdAsync(id);
            return Ok(word);
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {

                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(int id, WordUpdateDto dto)
    {
        try
        {
            await _service.UpdateAsync(id, dto);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is IBaseException ibe)
            {

                return StatusCode(ibe.StatusCode, new
                {
                    StatusCode = ibe.StatusCode,
                    Message = ibe.ErrorMessage
                });
            }
            else
            {
                return BadRequest(new
                {
                    StatusCode = StatusCodes.Status400BadRequest,
                    Message = ex.Message
                });
            }
        }

    }


}
