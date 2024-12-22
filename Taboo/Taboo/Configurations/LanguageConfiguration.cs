using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Taboo.Entities;

namespace Taboo.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {

            builder
                .HasKey(x => x.Code);
           
            builder
                .Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(2);
            builder
               .HasIndex(x => x.Name)
               .IsUnique();
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder
                .Property(x => x.Icon)
                .IsRequired()
                .HasMaxLength(128);
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
