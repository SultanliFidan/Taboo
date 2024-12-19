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
            
            
        }
    }
}
