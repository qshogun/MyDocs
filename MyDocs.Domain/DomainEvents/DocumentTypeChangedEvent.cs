using MyDocs.Domain.Abstractions;
using MyDocs.Domain.Enums;

namespace MyDocs.Domain.DomainEvents;

public class DocumentTypeChangedEvent : DomainEvent
{
    public Guid DocumentId { get; set; }
    public DocumentType NewDocumentType { get; set; }

    public DocumentTypeChangedEvent(Guid documentId, DocumentType newDocumentType)
    {
        DocumentId = documentId;
        NewDocumentType = newDocumentType;
    }
}
