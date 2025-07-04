using Productivity.Domain.Common.Enumerations;
using Productivity.Domain.Common.Models;
using Productivity.Domain.Common.ValueObjects;
using Productivity.Domain.EpicAggregate.Entities;

namespace Productivity.Domain.EpicAggregate;

public sealed class Epic : AggregateRoot<EpicId>
{
    private List<EpicDependency> _dependencies = new();
    private List<StoryId> _stories = new();
    private List<SubtaskId> _subtasks = new();
    private List<FileId> _attachments = new();
    private List<string> _tags = new();

    public WorkspaceId WorkspaceId { get; }
    public UserId? AssigneeId { get; }

    public string Title { get; set; }
    public string? Description { get; set; }

    public TaskStatusProgression Status { get; private set; }
    public TaskPriority Priority { get; private set; }

    public DateRange? EstimatedPeriod { get; private set; }
    public DateRange? RealizedPeriod { get; private set; }

    public IReadOnlyCollection<StoryId> Stories => _stories.AsReadOnly();
    public IReadOnlyCollection<SubtaskId> Subtasks => _subtasks.AsReadOnly();
    public IReadOnlyCollection<EpicDependency> Dependencies => _dependencies.AsReadOnly();

    public IReadOnlyCollection<FileId> Attachments => _attachments.AsReadOnly();
    public IReadOnlyCollection<string> Tags => _tags.AsReadOnly();

    public AuditMetadata AuditMetadata { get; }

    //If this property is true then the Assignee user of the Epic should be a team leader in a team that is within the given workspace.
    //If the value of the property is set to "true", then the team leader gains access to assign tasks to the team within the given epic.
    public bool IsAssignedToTeam { get; private set; }

    private Epic(EpicId id, string title, WorkspaceId workspaceId, UserId creatorId) : base(id)
    {
        Title = title;
        WorkspaceId = workspaceId;
        AuditMetadata = new AuditMetadata(creatorId, DateTime.UtcNow);
    }

    public Epic Create(string title, WorkspaceId workspaceId, UserId creatorId)
    {
        return new(EpicId.CreateUnique(), title, workspaceId, creatorId);
    }
}
