using Taboo.DTOs.Games;
using Taboo.Entities;

namespace Taboo.Services.Abstracts
{
    public interface IGamesService
    {
        Task<Guid> AddAsync(GameCreateDto dto);
        Task StartAsync(Guid id);
        Task<Game> GetCurrentStatus(Guid id);
    }
}
