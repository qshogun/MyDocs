using MyDocs.Domain.Entities;

namespace MyDocs.Domain.Repositories;

public interface IFamilyMemberRepository
{
    Task<FamilyMember> GetByIdAsync(Guid familyMemberId);
    Task<IEnumerable<FamilyMember>> GetAllAsync();
    Task AddAsync(FamilyMember familyMember);
    Task UpdateAsync(FamilyMember familyMember);
    Task DeleteAsync(Guid familyMemberId);
}
