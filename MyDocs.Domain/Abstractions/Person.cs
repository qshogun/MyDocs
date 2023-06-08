using MyDocs.Domain.Enums;

namespace MyDocs.Domain.Abstractions;

public abstract class Person : IPerson
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; init; }
    public Gender Gender { get; init; }

    internal Person(string firstName, string lastName, DateTime dateOfBirth, Gender gender)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.DateOfBirth = dateOfBirth;
        this.Gender = gender;
    }

    internal Person() { }
}