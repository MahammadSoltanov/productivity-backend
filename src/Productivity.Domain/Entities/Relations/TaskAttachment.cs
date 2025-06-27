namespace Productivity.Domain.Entities.Relations;

public class TaskAttachment /*: Entity*/
{
    public TaskAttachment(Guid attachmentId, Guid taskId)
    {
        AttachmentId = attachmentId;
        TaskId = taskId;
    }

    public FileStorage Attachment { get; private set; }
    public Guid AttachmentId { get; private set; }
    public Task Task { get; private set; }
    public Guid TaskId { get; private set; }
}
