using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.UserAggregate;
using Productivity.Domain.UserAggregate.ValueObjects;
using System.Text.Json;

namespace Productivity.Infrastructure.Persistence.Configurations;
internal class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
               .ValueGeneratedNever()
               .HasConversion(id => id.Value, value => UserId.Create(value));

        builder.Property(u => u.FirstName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.LastName)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Email)
            .HasMaxLength(254)
            .IsRequired();

        builder.Property(u => u.PasswordHash)
            .HasMaxLength(255)
            .IsRequired();

        var settings = builder.OwnsOne(u => u.AccountSettings);

        settings.Property(s => s.Theme)
            .HasColumnName("Theme")
            .IsRequired();

        settings.Property(s => s.ItemsPerPage)
            .HasColumnName("ItemsPerPage");


        settings.Property(s => s.DefaultTimeZone)
                .HasColumnName("DefaultTimeZoneId")
                .HasConversion(
                    tz => tz == null ? null : tz.Id,
                    id => id == null
                          ? null
                          : TimeZoneInfo.FindSystemTimeZoneById(id));

        settings.Property(s => s.EnabledChannels)
            .HasColumnName("EnabledChannelsJson")
            .HasColumnType("nvarchar(max)")
            .HasConversion(
                    v => JsonSerializer
                        .Serialize(v, (JsonSerializerOptions?)null),

                    v => JsonSerializer
                        .Deserialize<IReadOnlySet<NotificationChannel>>(v, (JsonSerializerOptions?)null)!
                )
                .Metadata
                .SetValueComparer(new ValueComparer<IReadOnlySet<NotificationChannel>>
                (
                    (a, b) => a.SetEquals(b),
                    a => a.Aggregate(0, (h, c) => HashCode.Combine(h, c.GetHashCode())),
                    a => a.ToHashSet()
                ));

        settings.Property(s => s.MutedNotificationTypes)
                .HasColumnName("MutedNotificationTypesJson")
                .HasColumnType("nvarchar(max)")
                .HasConversion(
                    v => JsonSerializer
                        .Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer
                        .Deserialize<IReadOnlySet<NotificationType>>(v, (JsonSerializerOptions?)null)!
                )
                .Metadata
                .SetValueComparer(new ValueComparer<IReadOnlySet<NotificationType>>
                (
                    (a, b) => a.SetEquals(b),
                    a => a.Aggregate(0, (h, c) => HashCode.Combine(h, c.GetHashCode())),
                    a => a.ToHashSet()
                ));
    }
}
