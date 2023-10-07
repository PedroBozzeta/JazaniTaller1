using Jazani.Infrastructure.Cores.Converters;
using JazaniT1.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniT1.Infrastructure.Admins.Configurations
{
    public class InvestmentConfiguration : IEntityTypeConfiguration<Investment>
    {
        public void Configure(EntityTypeBuilder<Investment> builder)
            {
                builder.ToTable("investment", "mc");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.AmountInvestd).HasColumnName("amountinvestd");
                builder.Property(x => x.Description).HasColumnName("description");
                builder.Property(x => x.Year).HasColumnName("year");
                builder.Property(x => x.RegistrationDate)
                    .HasColumnName("registrationdate")
                    .HasConversion(new DateTimeToDateTimeOffset());
                builder.Property(x => x.State).HasColumnName("state");
                builder.HasOne(one => one.Holder).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.HolderId);
                builder.HasOne(one => one.InvestmentConcept).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.InvestmentConceptId);
                builder.HasOne(one => one.InvestmentType).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.InvestmentTypeId);
                builder.HasOne(one => one.MeasureUnit).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.MeasureUnitId);
                builder.HasOne(one => one.MiningConcession).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.MiningConcessionId);
                builder.HasOne(one => one.PeriodType).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.PeriodTypeId);
        }
    }
}