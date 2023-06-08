using MyDocs.Domain.Abstractions;
using MyDocs.Domain.Entities;

namespace MyDocs.Domain.DomainEvents;

public class FamilyMemberUpdated : DomainEvent
{
    public FamilyMember FamilyMember { get; }

    public FamilyMemberUpdated(FamilyMember familyMember)
    {
        FamilyMember = familyMember;
    }
}

