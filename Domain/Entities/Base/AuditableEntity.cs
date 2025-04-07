namespace Domain.Entities.Base;
public class AuditableEntity : Entity
{
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}