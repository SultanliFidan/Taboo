using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.BannedWords;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.BannedWord;
using Taboo.Exceptions.Word;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class BannedWordService(TabooDbContext _context, IMapper _mapper) : IBannedWordService
    {
        

        public async Task DeleteBannedWordAsync(int id)
        {
            var word = await _context.BannedWords.FindAsync(id);
            if (word is null)
                throw new BannedWordNotFoundException();
            _context.BannedWords.Remove(word);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BannedWordGetDto>> GetAllAsync()
        {
            var word = await _context.BannedWords.ToListAsync();
            var wordDto = _mapper.Map<IEnumerable<BannedWordGetDto>>(word);
            return wordDto;
        }

        public async Task<BannedWordGetDto> GetBannedWordByIdAsync(int id)
        {
            var word = await _context.BannedWords.FindAsync(id);
            if (word is null)
                throw new BannedWordNotFoundException();
            var wordDto = _mapper.Map<BannedWordGetDto>(word);
            return wordDto;
        }

        public async Task UpdateAsync(int id, BannedWordUpdateDto dto)
        {
            var word = await _context.BannedWords.FindAsync(id);
            if (word is null)
                throw new BannedWordNotFoundException();
            _mapper.Map(dto, word);
            await _context.SaveChangesAsync();
        }
    }
}
