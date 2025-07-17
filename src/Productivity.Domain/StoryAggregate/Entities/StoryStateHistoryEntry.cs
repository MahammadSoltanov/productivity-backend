using Productivity.Domain.Common.Abstract;
using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.ValueObjects;

namespace Productivity.Domain.StoryAggregate.Entities;
public class StoryStateHistoryEntry : TaskStateHistoryEntry<StoryStateHistoryEntryId, StoryId>
{
    public StoryStateHistoryEntry(StoryStateHistoryEntryId id,
                                  StoryId taskId,
                                  UserId initiatorId,
                                  UserId assigneeId,
                                  TaskStatus status,
                                  TaskPriority priority,
                                  DateRange validityPeriod) : base(id, taskId, initiatorId, assigneeId, status, priority, validityPeriod)
    {
    }
}