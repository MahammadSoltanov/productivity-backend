using Productivity.Domain.Common.Abstract;
using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.EpicAggregate.Entities;
public class EpicStateHistoryEntry : TaskStateHistoryEntry<EpicStateHistoryEntryId, EpicId>
{
    public EpicStateHistoryEntry(EpicStateHistoryEntryId id,
                                  EpicId taskId,
                                  TaskStatus status,
                                  TaskPriority priority,
                                  DateRange validityPeriod) : base(id, taskId, status, priority, validityPeriod)
    {
    }
}