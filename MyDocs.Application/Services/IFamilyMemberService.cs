using MyDocs.Models.DTOs;

namespace MyDocs.Application.Services
{
    public interface IFamilyMemberService
    {
        Task<FamilyMemberDTO> AddFamilyMember(FamilyMemberDTO familyMember);
        Task<FamilyMemberDTO> GetFamilyMember(Guid familyMemberId);
        Task<List<FamilyMemberDTO>> GetAllFamilyMembers();
        Task UpdateFamilyMember(FamilyMemberDTO familyMember);
        Task DeleteFamilyMember(Guid familyMemberId);
    }
}