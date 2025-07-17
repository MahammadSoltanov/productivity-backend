using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Exceptions;
using Productivity.Domain.Common.Models;

namespace Productivity.Domain.NotificationAggregate;
public sealed class Notification : AggregateRoot<NotificationId>
{
    public UserId RecipientId { get; }
    public NotificationType Type { get; }
    public NotificationChannel Channel { get; }
    public string Content { get; }
    public DateTime CreatedAt { get; }
    public NotificationStatus Status { get; private set; }
    public DateTime? ReadAt { get; private set; }

    private Notification(
      NotificationId id,
      UserId recipientId,
      NotificationType type,
      NotificationChannel channel,
      string content,
      DateTime createdAt) : base(id)
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
            throw new DomainException("Notification content cannot be empty.");

        return new(
          NotificationId.CreateUnique(),
          recipientId,
          type,
          channel,
          content,
          DateTime.UtcNow);
    }

    public void MarkAsRead(DateTime when)
    {
        if (Status != NotificationStatus.Unread)
            throw new DomainException("Only unread notifications can be marked as read.");

        Status = NotificationStatus.Read;
        ReadAt = when;
    }

    public void Dismiss()
    {
        if (Status == NotificationStatus.Dismissed)
            throw new DomainException("Notification is already dismissed.");

        Status = NotificationStatus.Dismissed;
    }
}

