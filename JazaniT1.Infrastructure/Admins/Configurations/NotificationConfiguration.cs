using Jazani.Infrastructure.Cores.Converters;
using JazaniT1.Domain.Admins.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JazaniT1.Infrastructure.Admins.Configurations
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        //Configuración de la entidad Notification
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("notification", "ge");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.NotificationActionId).HasColumnName("notificationactionid");
            builder.Property(x => x.RegistrationDate)
                .HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());
            builder.Property(x => x.State).HasColumnName("state");
            builder.HasOne(one => one.NotificationAction).WithMany(many => many.Notifications)
                .HasForeignKey(fk => fk.NotificationActionId);
        }
    }
}
