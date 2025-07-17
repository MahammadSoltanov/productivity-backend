using Productivity.Domain.Common.Abstract;
using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.SubtaskAggregate.Entities;
public class SubtaskStateHistoryEntry : TaskStateHistoryEntry<SubtaskStateHistoryEntryId, SubtaskId>
{
    public SubtaskStateHistoryEntry(SubtaskStateHistoryEntryId id,
                                    SubtaskId taskId,
                                    UserId initiatorId,
                                    UserId assigneeId,
                                    TaskStatus status,
                                    TaskPriority priority,
                                    DateRange validityPeriod) : base(id, taskId, initiatorId, assigneeId, status, priority, validityPeriod)
    {
    }
}