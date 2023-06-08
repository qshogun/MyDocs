using MyDocs.Domain.Abstractions;
using MyDocs.Domain.Entities;

namespace MyDocs.Domain.DomainEvents;

public class FamilyMemberAdded : DomainEvent
{
    public FamilyMember FamilyMember { get; }

    public FamilyMemberAdded(FamilyMember familyMember)
    {
        FamilyMember = familyMember;
    }
}

