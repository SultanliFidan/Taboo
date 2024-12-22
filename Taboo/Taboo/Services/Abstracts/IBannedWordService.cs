using Taboo.DTOs.BannedWords;
using Taboo.DTOs.Words;

namespace Taboo.Services.Abstracts
{
    public interface IBannedWordService
    {
       
        Task<IEnumerable<BannedWordGetDto>> GetAllAsync();
        Task DeleteBannedWordAsync(int id);
        Task<BannedWordGetDto> GetBannedWordByIdAsync(int id);
        Task UpdateAsync(int id, BannedWordUpdateDto dto);
    }
}
