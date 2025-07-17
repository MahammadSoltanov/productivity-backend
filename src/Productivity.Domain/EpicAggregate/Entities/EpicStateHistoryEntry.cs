using Productivity.Domain.Common.Abstract;
using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.EpicAggregate.Entities;
public class EpicStateHistoryEntry : TaskStateHistoryEntry<EpicStateHistoryEntryId, EpicId>
{
    public EpicStateHistoryEntry(EpicStateHistoryEntryId id,
                                  EpicId taskId,
                                  UserId initiatorId,
                                  UserId assigneeId,
                                  TaskStatus status,
                                  TaskPriority priority,
                                  DateRange validityPeriod) : base(id, taskId, initiatorId, assigneeId, status, priority, validityPeriod)
    {
    }
}