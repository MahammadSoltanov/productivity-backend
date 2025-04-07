namespace Domain.Entities;

using Domain.Entities.Base;

public class Attachment : Entity
{
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public DateTime UploadedAt { get; set; }
}
