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
                builder.Property(x => x.Year).HasColumnName("year");
                builder.Property(x => x.Description).HasColumnName("description");
                builder.Property(x => x.MiningConcessionId).HasColumnName("miningconcessionid");
                builder.Property(x => x.InvestmentTypeId).HasColumnName("investmenttypeid");
                builder.Property(x => x.CurrencyTypeId).HasColumnName("currencytypeid");
                builder.Property(x => x.PeriodTypeId).HasColumnName("periodtypeid").IsRequired(false);
                builder.Property(x => x.MeasureUnitId).HasColumnName("measureunitid").IsRequired(false);
                builder.Property(x => x.HolderId).HasColumnName("holderid");
                builder.Property(x => x.DeclaredTypeId).HasColumnName("declaredtypeid");
                builder.Property(x => x.InvestmentConceptId).HasColumnName("investmentconceptid").IsRequired(false);
                builder.Property(x => x.RegistrationDate)
                    .HasColumnName("registrationdate")
                    .HasConversion(new DateTimeToDateTimeOffset());
                builder.Property(x => x.State).HasColumnName("state");

                builder.HasOne(one => one.MiningConcession).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.MiningConcessionId);
                builder.HasOne(one => one.InvestmentType).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.InvestmentTypeId);
                builder.HasOne(one => one.PeriodType).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.PeriodTypeId);
                builder.HasOne(one => one.MeasureUnit).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.MeasureUnitId);
                builder.HasOne(one => one.Holder).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.HolderId);
                builder.HasOne(one => one.InvestmentConcept).WithMany(many => many.Investments)
                .HasForeignKey(fk => fk.InvestmentConceptId);
        }
    }
}