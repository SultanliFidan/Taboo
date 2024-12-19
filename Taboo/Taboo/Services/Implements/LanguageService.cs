using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Taboo.DAL;
using Taboo.DTOs.Languages;
using Taboo.Entities;
using Taboo.Exceptions.Language;
using Taboo.Services.Abstracts;

namespace Taboo.Services.Implements
{
    public class LanguageService(TabooDbContext _context, IMapper _mapper) : ILanguageService
    {
        public async Task CreateAsync(LanguageCreateDto dto)
        {
            if (await _context.Languages.AnyAsync (x => x.Code == dto.Code))
                throw new LanguageExistException();
            var lang = _mapper.Map<Language>(dto);
            await _context.Languages.AddAsync(lang);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string code)
        {
            var lang = await _context.Languages.FindAsync(code);
            if (lang is null)
                throw new Exception("Language not founded");
            _context.Languages.Remove(lang);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LanguageGetDto>> GetAllAsync()
        {
            var langs = await _context.Languages.ToListAsync();
            var languageDto = _mapper.Map<IEnumerable<LanguageGetDto>>(langs);  
            return languageDto;
        }

        public async Task<LanguageGetDto> GetByCodeAsync(string code)
        {
            var lang = await _context.Languages.FindAsync(code);
            if (lang is null)
                throw new Exception("Language not founded");
            var langDto = _mapper.Map<LanguageGetDto>(lang);
            return langDto;
        }

        public async Task UpdateAsync(string code, LanguageUpdateDto dto)
        {
            var lang = await _getByCode(code);
            if (lang is null)
                throw new LanguageNotFoundException();
            _mapper.Map(dto,lang);
            

            await _context.SaveChangesAsync();

        }

        async Task<Language?> _getByCode(string code)
        {
            return await _context.Languages.FindAsync(code);
        }
    }
}
