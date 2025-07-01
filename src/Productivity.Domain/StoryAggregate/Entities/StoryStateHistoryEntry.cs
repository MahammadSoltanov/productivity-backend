using Productivity.Domain.Common.Abstract;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.Enumerations;

namespace Productivity.Domain.StoryAggregate.Entities;
public class StoryStateHistoryEntry : TaskStateHistoryEntry<StoryStateHistoryEntryId, StoryId>
{
    public StoryStateHistoryEntry(StoryStateHistoryEntryId id,
                                  StoryId taskId,
                                  TaskStatus status,
                                  TaskPriority priority,
                                  DateRange validityPeriod) : base(id, taskId, status, priority, validityPeriod)
    {
    }
}
