using Lottery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lottery.Infrastructure.Data.Mapping
{
    public class CampaignMap : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaigns");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Description)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder
                .HasOne(x => x.EmailTemplate)
                .WithOne(x => x.Campaign)
                .HasForeignKey<CampaignEmailTemplate>(x => x.Id);
            builder.OwnsOne(x => x.Period);
        }
    }
}