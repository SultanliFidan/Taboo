using Taboo.DTOs.Languages;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Services.Abstracts
{
    public interface IWordsService
    {
        Task CreateAsync(WordCreateDto dto);
        Task<IEnumerable<WordGetDto>> GetAllAsync();
        Task DeleteWordAsync(int id);
        Task<WordGetDto> GetWordByIdAsync(int id);
        Task UpdateAsync(int id, WordUpdateDto dto);
    }
}
