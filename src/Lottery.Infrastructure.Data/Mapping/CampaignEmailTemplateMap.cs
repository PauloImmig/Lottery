using Lottery.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lottery.Infrastructure.Data.Mapping
{
    public class CampaignEmailTemplateMap : IEntityTypeConfiguration<CampaignEmailTemplate>
    {
        public void Configure(EntityTypeBuilder<CampaignEmailTemplate> builder)
        {
            builder.ToTable("CampaignEmailTemplates");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Subject)
                .HasConversion(c => string.Join(',', c), x => new EmailSubject(x))
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Content)
                .HasConversion(c => c.ToString(), x => new EmailContent(x))
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Placeholders)
                .HasConversion(c => string.Join(',', c), x => new EmailContentPlaceholders(x))
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();
        }
    }
}
