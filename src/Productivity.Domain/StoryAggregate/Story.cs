using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.Time;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.StoryAggregate.Entities;

namespace Productivity.Domain.StoryAggregate;

public sealed class Story : AggregateRoot<StoryId>
{
    private List<StoryDependency> _dependencies = new();
    private List<SubtaskId> _subtasks = new();
    private List<FileId> _attachments = new();
    private List<string> _tags = new();
    private List<StoryComment> _comments = new();

    public EpicId EpicId { get; }
    public UserId? AssigneeId { get; }

    public string Title { get; set; }
    public string? Description { get; set; }

    public TaskStatusProgression Status { get; private set; }
    public TaskPriority Priority { get; private set; }

    public DateRange? EstimatedPeriod { get; private set; }
    public DateRange? RealizedPeriod { get; private set; }

    public IReadOnlyCollection<SubtaskId> Subtasks => _subtasks.AsReadOnly();
    public IReadOnlyCollection<StoryDependency> Dependencies => _dependencies.AsReadOnly();

    public IReadOnlyCollection<FileId> Attachments => _attachments.AsReadOnly();
    public IReadOnlyCollection<string> Tags => _tags.AsReadOnly();
    public IReadOnlyCollection<StoryComment> Comments => _comments.AsReadOnly();

    public AuditMetadata AuditMetadata { get; }

    private Story(StoryId id, string title, EpicId epicId, UserId creatorId) : base(id)
    {
        Title = title;
        EpicId = epicId;
        AuditMetadata = new AuditMetadata(creatorId, DomainTime.Current.UtcNow);
    }

    public Story Create(string title, EpicId epicId, UserId creatorId)
    {
        return new(StoryId.CreateUnique(), title, epicId, creatorId);
    }
}