using Lottery.Entities.Models;
using Lottery.SharedKernel.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lottery.Infrastructure.Data.Mapping
{
    public class ParticipantMap : IEntityTypeConfiguration<Participant>
    {
        public void Configure(EntityTypeBuilder<Participant> builder)
        {
            builder.ToTable("Participants");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("Id");

            builder.Property(c => c.Name)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Mail)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired()
                .HasConversion(x => x.ToString(), x => new EmailAddress(x));

            builder.Property(c => c.Action)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.City)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Country)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Details)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Entries)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Facebook)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Instagram)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Region)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.Status)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired()
                .HasConversion(x => x.ToString(), x => x);

            builder.Property(c => c.Twitter)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.When)
                .IsRequired();

            builder.Property(c => c.Youtube)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(c => c.LuckyNumber);

            builder.HasOne(c => c.Campaign)
                .WithMany(x => x.Participants)
                .HasForeignKey(c => c.CampaignId);
        }
    }
}
