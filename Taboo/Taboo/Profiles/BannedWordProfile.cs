using AutoMapper;
using Taboo.DTOs.BannedWords;
using Taboo.DTOs.Words;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class BannedWordProfile : Profile
    {
        public BannedWordProfile()
        {
            CreateMap<BannedWordCreateDto, BannedWord>()
               .ReverseMap();
            CreateMap<BannedWordGetDto, BannedWord>()
               .ReverseMap();
            CreateMap<BannedWordUpdateDto, BannedWord>()
               .ReverseMap();
        }
    }
}
