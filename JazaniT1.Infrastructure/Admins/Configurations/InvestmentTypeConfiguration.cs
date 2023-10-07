using Jazani.Infrastructure.Cores.Converters;
using JazaniT1.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniT1.Infrastructure.Admins.Configurations
{
    public class InvestmentTypeConfiguration: IEntityTypeConfiguration<InvestmentType>
    {
        public void Configure(EntityTypeBuilder<InvestmentType> builder)
        {
            builder.ToTable("investmenttype", "mc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
