using Domain.Entities.Base;

namespace Domain.Entities;

public sealed class Workspace : AuditableEntity
{
    public Workspace(string name, User creator)
    {
        Name = name;
        Creator = creator;
    }

    public string Name { get; set; }
    public string? Desciption { get; set; }
    public Guid CreatorId { get; set; }
    public User Creator { get; set; }
    public Guid? DefaultAssigneeId { get; set; }
    public User? DefaultAssignee { get; set; }
}
