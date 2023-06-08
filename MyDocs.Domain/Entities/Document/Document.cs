using MyDocs.Domain.Enums;

namespace MyDocs.Domain.Entities;

public class Document
{
    public System.Guid Id { get; init; }
    public DocumentType DocumentType { get; set; } = DocumentType.Other;
    public string Title { get; set; } = string.Empty;
    public DateTime IssueDate { get; set; } = DateTime.UtcNow;
    public string FilePath { get; set; } = string.Empty;
    public string Notes { get; set; } = string.Empty;
    public FamilyMember? AssociatedFamilyMember { get; set; }

    private Document()
    {
        Id = System.Guid.NewGuid();
    }

    public static Document Create()
    {
        return new Document();
    }

    public Document WithType(DocumentType type)
    {
        DocumentType = type;
        return this;
    }

    public Document WithTitle(string title)
    {
        Title = title;
        return this;
    }

    public Document WithIssueDate(DateTime issueDate)
    {
        IssueDate = issueDate;
        return this;
    }

    public Document WithFilePath(string filePath)
    {
        FilePath = filePath;
        return this;
    }

    public Document WithNotes(string notes)
    {
        Notes = notes;
        return this;
    }

    public Document WithAssociatedFamilyMember(FamilyMember familyMember)
    {
        AssociatedFamilyMember = familyMember;
        return this;
    }
}
