using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.Entities.Relations;

public class TaskAttachment<TTaskId>
{
    public TaskAttachment(FileId attachmentId, TTaskId taskId)
    {
        AttachmentId = attachmentId;
        TaskId = taskId;
    }

    public FileStorage Attachment { get; private set; }
    public FileId AttachmentId { get; private set; }
    public TTaskId TaskId { get; private set; }
}
