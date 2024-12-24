using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Taboo.DAL;
using Taboo.DTOs.Games;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.Game;
using Taboo.ExternalServices.Abstracts;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class GameService(TabooDbContext _context, IMapper _mapper, ICacheService _cache) : IGamesService
    {
        public async Task<Guid> AddAsync(GameCreateDto dto)
        {
            var entity = _mapper.Map<Game>(dto);
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public Task EndAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetCurrentStatus(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity is null) throw new GameNotFoundException();
            if (entity.Score is not null) throw new GameAlreadyFinishedException();



            //entity.SuccessAnswer = _cache.Get<int>("SuccessAnswer");
            //entity.WrongAnswer = _cache.Get<int>("WrongAnswer");
            //entity.FailCount = _cache.Get<int>("FailCount");
            //entity.SkipCount = _cache.Get<int>("SkipCount");
            return entity;
        }

        public async Task<WordForGameDto> PassAsync(Guid id)
        {
           var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            if (status.Pass < status.MaxPassCount)
            {
               status.Pass++;
                var word =  status.Words.Pop();
                await _cache.SetAsync(id.ToString(), status);
                return word;
            }
            return null;
        }

        public async Task<WordForGameDto> StartAsync(Guid id)
        {
            var entity = await _context.Games.FindAsync(id);
            if (entity is null) throw new GameNotFoundException();
            if (entity.Score is not null) throw new GameAlreadyFinishedException();
            var words = await _context.Words.Where(x => x.LanguageCode == entity.LanguageCode).Take(10)
                .Select(x => new WordForGameDto
                {
                    Id = x.Id,
                    Name = x.Text,
                    BannedWords = x.BannedWords.Select(y => y.Text).ToList()
                }).ToListAsync();
            GameStatusDto status = new GameStatusDto
            {
                Pass = 0,
                Success = 0,
                Wrong = 0,
                Words = new Stack<WordForGameDto>(words),
                UsedWordsIds = words.Select(x => x.Id).ToList(),
                LangCode = entity.LanguageCode,
                MaxPassCount = (byte)entity.SkipCount
            };
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status);
            return word;

            //_cache.Set("SuccessAnswer", entity.SuccessAnswer, TimeSpan.FromMinutes(30));
            //_cache.Set("WrongAnswer", entity.WrongAnswer, TimeSpan.FromMinutes(30));
            //_cache.Set("FailCount", entity.FailCount, TimeSpan.FromMinutes(30));
            //_cache.Set("SkipCount", entity.SkipCount, TimeSpan.FromMinutes(30));

        }

        public async Task<WordForGameDto> SuccesAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            status.Success++;
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(),status);
            return word;
        }

        public async Task<WordForGameDto> WrongAsync(Guid id)
        {
            var status = await _getGameStatusAsync(id);
            await _addNewWords(status);
            status.Wrong++;
            var word = status.Words.Pop();
            await _cache.SetAsync(id.ToString(), status);
            return word;
        }

        async Task<GameStatusDto> _getGameStatusAsync(Guid id)
        {
            GameStatusDto status = await _cache.GetAsync<GameStatusDto>(id.ToString());
            if (status is null)
                throw new GameNotFoundException();
               return(status);
        }

        async Task _addNewWords(GameStatusDto status)
        {
            if(status.Words.Count < 6)
            {
                var newWords = await _context.Words.Where(w => w.LanguageCode ==
            status.LangCode && !status.UsedWordsIds.Contains(w.Id)).Take(5).Select(x => new WordForGameDto
            {
                Id = x.Id,
                Name = x.Text,
                BannedWords = x.BannedWords.Select(y => y.Text).ToList()
            }).ToListAsync();

                status.UsedWordsIds.AddRange(newWords.Select(x => x.Id));
                newWords.ForEach(x => status.Words.Push(x));
            }
            
        }
    }
}
