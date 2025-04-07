namespace Domain.Entities.HistoricalRecords;

using Domain.Entities.Base;
using Domain.Enumerations;

public class TaskHistory : HistoricalEntity
{
    public Guid TaskId { get; set; }
    public TaskStatus Status { get; set; }
    public TaskPriority Priority { get; set; }
    public TaskType TaskType { get; set; }
    public DateTime StatusChangedAt { get; set; }
}
