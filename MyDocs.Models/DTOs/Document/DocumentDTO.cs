using MyDocs.Domain.Enums;

namespace MyDocs.Models.DTOs;

public class DocumentDTO
{
    public Guid DocumentId { get; set; }
    public DocumentType DocumentType { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; }
    public string FilePath { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
}
