namespace MyDocs.Models.DTOs;

public class FamilyMemberCreateDTO
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Gender { get; set; } = string.Empty; // Use string representation
    public string Relationship { get; set; } = string.Empty; // Use string representation
}
