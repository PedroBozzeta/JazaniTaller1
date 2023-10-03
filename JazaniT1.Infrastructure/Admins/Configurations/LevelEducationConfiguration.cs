using Microsoft.EntityFrameworkCore;
using JazaniT1.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace JazaniT1.Infrastructure.Admins.Configurations
{
    public class LevelEducationConfiguration : IEntityTypeConfiguration<LevelEducation>
    {
        //Configuración de la entidad LevelEducation
        public void Configure(EntityTypeBuilder<LevelEducation> builder)
        {
            builder.ToTable("leveleducation", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.RegistrationDate).HasColumnName("registrationdate");
            builder.Property(x => x.State).HasColumnName("state");
        }
    }
}
