namespace Productivity.Domain.Entities.Base;

public class HistoricalEntity : Entity
{
    public DateTime ValidFrom { get; set; }
    public DateTime? ValidTo { get; set; }
}
