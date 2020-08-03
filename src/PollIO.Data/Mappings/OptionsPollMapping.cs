using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollIO.Business.Models;

namespace PollIO.Data.Mappings
{
    public class OptionsPollMapping : IEntityTypeConfiguration<OptionsPoll>
    {
        public void Configure(EntityTypeBuilder<OptionsPoll> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(o => o.Votes)
                .HasColumnType("varchar(50)");

            builder.ToTable("OptionsPolls");
        }
    }
}
