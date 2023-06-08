using MyDocs.Domain.Abstractions;
using MyDocs.Domain.Enums;

namespace MyDocs.Domain.Entities;

public class User : Person
{
    public Guid Id { get; init; }
    public string PasswordHash { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public ICollection<FamilyMember> FamilyMembers { get; set; } = new HashSet<FamilyMember>();

    private User(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
        : base(firstName, lastName, dateOfBirth, gender)
    {
        Id = Guid.NewGuid();

        FamilyMembers.Add(
            FamilyMember
            .Create(FirstName, LastName, DateOfBirth, Gender, Relationship.Self)
            );
    }

    public static User Create(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
    {
        return new User(firstName, lastName, dateOfBirth, gender);
    }

    public User WithPassword(string password)
    {
        PasswordHash = password;
        return this;
    }

    public User WithEmail(string email)
    {
        Email = email;
        return this;
    }
}

