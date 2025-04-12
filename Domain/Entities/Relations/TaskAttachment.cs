using Domain.Entities.Base;

namespace Domain.Entities.Relations;

public class TaskAttachment : Entity
{
    public TaskAttachment(FileStorage attachment, Task task)
    {
        Attachment = attachment;
        AttachmentId = attachment.Id;
        Task = task;
        TaskId = task.Id;
    }

    public FileStorage Attachment { get; private set; }
    public Guid AttachmentId { get; private set; }
    public Task Task { get; private set; }
    public Guid TaskId { get; private set; }
}
