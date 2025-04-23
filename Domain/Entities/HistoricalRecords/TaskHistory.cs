using Domain.Entities.Base;
using Domain.Enumerations;

namespace Domain.Entities.HistoricalRecords;

public class TaskHistory : HistoricalEntity
{
    public TaskHistory(Guid taskId, TaskStatus status, TaskPriority priority, TaskType taskType)
    {
        TaskId = taskId;
        Status = status;
        Priority = priority;
        TaskType = taskType;
    }

    public Guid TaskId { get; private set; }
    public TaskStatus Status { get; private set; }
    public TaskPriority Priority { get; private set; }
    public TaskType TaskType { get; private set; }
}
