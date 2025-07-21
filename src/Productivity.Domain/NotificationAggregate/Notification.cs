using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.Time;

namespace Productivity.Domain.NotificationAggregate;
public sealed class Notification : AggregateRoot<NotificationId>
{
    public UserId RecipientId { get; }
    public NotificationType Type { get; }
    public NotificationChannel Channel { get; }
    public string Content { get; }
    public DateTimeOffset CreatedAt { get; }
    public NotificationStatus Status { get; private set; }
    public DateTimeOffset? ReadAt { get; private set; }

    private Notification(
      NotificationId id,
      UserId recipientId,
      NotificationType type,
      NotificationChannel channel,
      string content,
      DateTimeOffset createdAt) : base(id)
    {
        RecipientId = recipientId;
        Type = type;
        Channel = channel;
        Content = content;
        CreatedAt = createdAt;
        Status = NotificationStatus.Unread;
    }

    public static Notification Create(
      UserId recipientId,
      NotificationType type,
      NotificationChannel channel,
      string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new DomainException("Notification content cannot be empty.");
        }

        return new(
          NotificationId.CreateUnique(),
          recipientId,
          type,
          channel,
          content,
          DomainTime.Current.UtcNow);
    }

    public void MarkAsRead(DateTimeOffset when)
    {
        if (Status != NotificationStatus.Unread)
        {
            throw new DomainException("Only unread notifications can be marked as read.");
        }

        Status = NotificationStatus.Read;
        ReadAt = when;
    }

    public void Dismiss()
    {
        if (Status == NotificationStatus.Dismissed)
        {
            throw new DomainException("Notification is already dismissed.");
        }

        Status = NotificationStatus.Dismissed;
    }
}

