using MyDocs.Domain.Abstractions;
using MyDocs.Domain.Enums;

namespace MyDocs.Domain.Entities;

public class FamilyMember : Person
{
    public Guid Id { get; init; }
    public Relationship RelationshipTowardsUser { get; init; }
    //public ICollection<Document> Documents { get; set; } = new List<Document>();

    private FamilyMember(string firstName, string lastName, DateTime dateOfBirth, Gender gender, Relationship relationshipTowardsUser)
        : base(firstName, lastName, dateOfBirth, gender)
    {
        Id = Guid.NewGuid();
        RelationshipTowardsUser = relationshipTowardsUser;
    }
    public FamilyMember() // Parameterless constructor for AutoMapper
    {
    }

    public static FamilyMember Create(string firstName, string lastName, DateTime dateOfBirth, Gender gender, Relationship relationshipTowardsUser)
    {
        return new FamilyMember(firstName, lastName, dateOfBirth, gender, relationshipTowardsUser);
    }

}
