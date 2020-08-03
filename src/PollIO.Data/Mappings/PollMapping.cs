using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollIO.Business.Models;

namespace PollIO.Data.Mappings
{
    public class PollMapping : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Poll_description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Views)
                .HasColumnType("varchar(50)");

            builder.HasMany(p => p.Options)
                .WithOne(o => o.Poll)
                .HasForeignKey(o => o.PollId);

            builder.ToTable("Polls");
        }
    }
}
