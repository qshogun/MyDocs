using MyDocs.Domain.Abstractions;
using MyDocs.Domain.Entities;

namespace MyDocs.Domain.DomainEvents;

public class DocumentAddedToFamilyMember : DomainEvent
{
    public FamilyMember FamilyMember { get; }
    public Document Document { get; }

    public DocumentAddedToFamilyMember(FamilyMember familyMember, Document document)
    {
        FamilyMember = familyMember;
        Document = document;
    }
}
