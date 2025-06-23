using Productivity.Domain.Entities.Base;

namespace Productivity.Domain.Entities;

public class FileStorage : Entity
{
    public string FileName { get; set; }
    public string FileUrl { get; set; }
    public DateTime UploadedAt { get; set; }
}
