using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Taboo.DAL;
using Taboo.DTOs.Games;
using Taboo.Entities;
using Taboo.Exceptions.Game;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class GameService(TabooDbContext _context, IMapper _mapper, IMemoryCache _cache) : IGamesService
    {
        public async Task<Guid> AddAsync(GameCreateDto dto)
        {
            var entity = _mapper.Map<Game>(dto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<Game> GetCurrentStatus(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity is null) throw new GameNotFoundException();
            if (entity.Score is not null) throw new GameAlreadyFinishedException();
            entity.SuccessAnswer = _cache.Get<int>("SuccessAnswer");
            entity.WrongAnswer = _cache.Get<int>("WrongAnswer");
            entity.FailCount = _cache.Get<int>("FailCount");
            entity.SkipCount = _cache.Get<int>("SkipCount");
            return entity;
        }

        public async Task StartAsync(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity is null) throw new GameNotFoundException();
            if (entity.Score is not null) throw new GameAlreadyFinishedException();
            _cache.Set("SuccessAnswer", entity.SuccessAnswer, TimeSpan.FromMinutes(30));
            _cache.Set("WrongAnswer", entity.WrongAnswer, TimeSpan.FromMinutes(30));
            _cache.Set("FailCount", entity.FailCount, TimeSpan.FromMinutes(30));
            _cache.Set("SkipCount", entity.SkipCount, TimeSpan.FromMinutes(30));





        }
    }
}
