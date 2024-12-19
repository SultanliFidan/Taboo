using Taboo.DTOs.Languages;
using Taboo.Entities;

namespace Taboo.Services.Abstracts
{
    public interface ILanguageService
    {
        Task<IEnumerable<LanguageGetDto>> GetAllAsync();
        Task CreateAsync(LanguageCreateDto dto);
        Task DeleteAsync(string code);
        Task<LanguageGetDto> GetByCodeAsync(string code);
        Task UpdateAsync(string code, LanguageUpdateDto dto);
    }
}
