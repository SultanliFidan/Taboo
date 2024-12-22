using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Words;
using Taboo.Entities;
using Taboo.Exceptions.Word;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class WordService(TabooDbContext _context, IMapper _mapper) : IWordsService
    {
        public async Task CreateAsync(WordCreateDto dto)
        {
            if (await _context.Words.AnyAsync(w => w.LanguageCode == dto.Language && w.Text == dto.Text))
            {
                throw new WordExistException();
            }
            if (dto.BannedWords.Count() != 6)
            {
                throw new InvalidBannedWordCountException();
            }

            //var word = _mapper.Map<Word>(dto);
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
           
        }

        public async Task DeleteWordAsync(int id)
        {
            var word = await _context.Words.FindAsync(id);
            if (word is  null)
                throw new WordNotFoundException();
            _context.Words.Remove(word);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<WordGetDto>> GetAllAsync()
        {
            var word = await _context.Words.Include(w => w.BannedWords).ToListAsync();
            var wordDto = _mapper.Map<IEnumerable<WordGetDto>>(word);
            return wordDto;
        }

        public async Task<WordGetDto> GetWordByIdAsync(int id)
        {
            var word = await _context.Words.Include(w => w.BannedWords).FirstOrDefaultAsync(w => w.Id == id);
            if (word is null)
                throw new WordNotFoundException();
            var wordDto = _mapper.Map<WordGetDto>(word);
            return wordDto;
        }

        public async Task UpdateAsync(int id, WordUpdateDto dto)
        {
            var word = await _context.Words.FindAsync(id);
            if (word is null)
                throw new WordNotFoundException();
            Word text = new Word
            {
                Text = dto.Text,
                BannedWords = dto.BannedWords.Select(x => new BannedWord
                {
                    Text = x,

                }).ToList()
            };
            await _context.SaveChangesAsync();

        }
    }
}
