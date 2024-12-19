using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Services.Abstracts
{
    public interface IWordsService
    {
        Task<int> CreateAsync(WordCreateDto dto);
        Task<IEnumerable<Word>> GetAllAsync();
    }
}
