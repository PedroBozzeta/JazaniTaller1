using Jazani.Infrastructure.Cores.Converters;
using JazaniT1.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniT1.Infrastructure.Admins.Configurations
{
    public class MiningConcessionConfiguration: IEntityTypeConfiguration<MiningConcession>
    {
        public void Configure(EntityTypeBuilder<MiningConcession> builder) {

            builder.ToTable("miningconcession", "mc");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasColumnName("code");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.MineralTypeId).HasColumnName("mineraltypeid");
            builder.Property(x => x.OriginId).HasColumnName("originid");
            builder.Property(x => x.SituationId).HasColumnName("situationid");
            builder.Property(x => x.MiningUnitId).HasColumnName("miningunitid");
            builder.Property(x => x.ConditionId).HasColumnName("conditionid");
            builder.Property(x => x.TypeId).HasColumnName("typeid");
            builder.Property(x => x.StateManagementId).HasColumnName("statemanagementid");
            builder.Property(x => x.IsSincronized).HasColumnName("issincronized");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
            
        }
    }
}
