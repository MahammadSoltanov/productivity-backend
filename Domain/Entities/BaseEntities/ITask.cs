namespace Domain.Entities.BaseEntities;

public interface ITask
{
    public DateTime StatusChangedAt { get; set; }
}
