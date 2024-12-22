using AutoMapper;
using Taboo.DTOs.Games;
using Taboo.Entities;

namespace Taboo.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameCreateDto,Game>()
                .ForMember(x => x.Time, y => y.MapFrom(z => new TimeSpan(10000000 * z.Seconds)))
                .ForMember(x=>x.BannedWordCount, y => y.MapFrom(z => (int)z.GameLevel));
        }
    }
}
