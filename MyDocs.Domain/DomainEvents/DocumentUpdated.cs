using MyDocs.Domain.Abstractions;
using MyDocs.Domain.Entities;

namespace MyDocs.Domain.DomainEvents;

public class DocumentUpdated : DomainEvent
{
    public Document Document { get; }

    public DocumentUpdated(Document document)
    {
        Document = document;
    }
}

