using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.Word;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class WordService(TabooDbContext _context) : IWordsService
    {
        public async Task<int> CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(w => w.LanguageCode == dto.Language && w.Text == dto.Text))
            {
                throw new Exception();
            }
            if (dto.BannedWords.Count() != 8)
            {
                throw new InvalidBannedWordCountException();
            }
            Word word = new Word
            {
                LanguageCode = dto.Language,
                Text = dto.Text,
                BannedWords = dto.BannedWords.Select(x => new BannedWord
                {
                    Text = x,

                }).ToList()
            };
            await _context.Words.AddAsync(word);
            await _context.SaveChangesAsync();
            return word.Id;
        }
        public async Task<IEnumerable<Word>> GetAllAsync()
        {
            return await _context.Words.ToListAsync();
        }
    }
}
