using AutoMapper;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class WordProfile : Profile
    {
        public WordProfile()
        {
            CreateMap<WordCreateDto,Word>()
                .ForMember(w => w.LanguageCode, d => d.MapFrom(t =>  t.Language))
                .ReverseMap();
            CreateMap<Word, WordGetDto>()
               .ForMember(w => w.Language, d => d.MapFrom(t => t.LanguageCode))
                .ForMember(w => w.BannedWords, d => d.MapFrom(t => t.BannedWords.Select(x => x.Text).ToList()))
               .ReverseMap();
            CreateMap<WordUpdateDto, Word>()
               .ReverseMap();
        }
    }
}
