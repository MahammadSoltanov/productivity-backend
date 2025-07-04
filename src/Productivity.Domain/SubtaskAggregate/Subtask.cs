using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.EpicAggregate.Entities;

namespace Productivity.Domain.SubtaskAggregate;

public sealed class Subtask : AggregateRoot<SubtaskId>
{
    private List<SubtaskDependency> _dependencies = new();
    private List<FileId> _attachments = new();
    private List<string> _tags = new();

    public StoryId? StoryId { get; set; }
    public EpicId? EpicId { get; set; }
    public UserId? AssigneeId { get; }

    public string Title { get; set; }
    public string? Description { get; set; }

    public TaskStatusProgression Status { get; private set; }
    public TaskPriority Priority { get; private set; }

    public DateRange? EstimatedPeriod { get; private set; }
    public DateRange? RealizedPeriod { get; private set; }

    public IReadOnlyCollection<SubtaskDependency> Dependencies => _dependencies.AsReadOnly();

    public IReadOnlyCollection<FileId> Attachments => _attachments.AsReadOnly();
    public IReadOnlyCollection<string> Tags => _tags.AsReadOnly();

    public AuditMetadata AuditMetadata { get; }


    public Subtask(SubtaskId id, string title, UserId creatorId, StoryId? storyId = null, EpicId? epicId = null) : base(id)
    {
        Title = title;
        StoryId = storyId;
        AuditMetadata = new AuditMetadata(creatorId, DateTime.UtcNow);
    }

    public Subtask CreateForStory(string title, StoryId storyId, UserId creatorId)
    {
        return new(SubtaskId.CreateUnique(), title, creatorId, storyId, null);
    }

    public Subtask CreateForEpic(string title, EpicId epicId, UserId creatorId)
    {
        return new(SubtaskId.CreateUnique(), title, creatorId, null, epicId);
    }
}
