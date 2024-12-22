using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Taboo.Entities;

namespace Taboo.Configurations
{
    public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
    {
        public void Configure(EntityTypeBuilder<BannedWord> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Text)
                .HasMaxLength(32);
            builder.HasOne(w => w.Word)
                .WithMany(b => b.BannedWords)
                .HasForeignKey(b => b.WordId);
        }
    }
}
