using MyDocs.Domain.Enums;

namespace MyDocs.Domain.Abstractions;

public interface IPerson
{
    DateTime DateOfBirth { get; init; }
    string FirstName { get; init; }
    Gender Gender { get; init; }
    string LastName { get; set; }
}