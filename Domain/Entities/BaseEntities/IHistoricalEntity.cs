namespace Domain.Entities.BaseEntities;

public interface IHistoricalEntity
{
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}
