using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Entities;

namespace Taboo.Configurations
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder
                .HasKey(x => x.Id);
            builder
                .Property(x => x.LanguageCode)
                .HasDefaultValue("az");
            builder
                .HasOne(x => x.Language)
                .WithMany(x => x.Games)
                .HasForeignKey(x => x.LanguageCode);
            builder.HasData(new Language
            {
                Code = "az",
                Name = "Azerbaycan",
                Icon = "https://i.pinimg.com/originals/3e/42/c7/3e42c70e701ca316775ee19d1bc08e4c.png"
            },
            new Language
            { 
                Code = "en",
                Name = "English",
                Icon = "https://www.citypng.com/public/uploads/preview/free-united-kingdom-england-uk-flag-icon-png-735811697023915sbq5vwe1oa.png"
            });
            
        }
    }
}
