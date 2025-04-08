using Domain.Entities.Base;

namespace Domain.Entities;

public class FileStorage : Entity
{
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public DateTime UploadedAt { get; set; }
}
