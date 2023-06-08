using MyDocs.Domain.Enums;

namespace MyDocs.Models.DTOs;

public class FamilyMemberDTO
{
    public Guid FamilyMemberId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public Gender Gender { get; set; } // Assume Gender is subclass of Enumeration
    public Relationship Relationship { get; set; } // Assume Relationship is subclass of Enumeration
    //public List<DocumentDTO> Documents { get; set; } = new List<DocumentDTO>();
}
