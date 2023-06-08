using Microsoft.EntityFrameworkCore;
using MyDocs.Domain.Entities;
using MyDocs.Domain.Repositories;
using MyDocs.Infrastructure.DB;

namespace MyDocs.Infrastructure.Repositories;

public class FamilyMemberRepository : IFamilyMemberRepository
{
    private readonly MyDocsDbContext _context;

    public FamilyMemberRepository(MyDocsDbContext context)
    {
        _context = context;
    }

    public async Task<FamilyMember?> GetByIdAsync(Guid id)
    {
        return await _context.FamilyMembers.FindAsync(id);
    }

    public async Task<IEnumerable<FamilyMember>> GetAllAsync()
    {
        return await _context.FamilyMembers.ToListAsync();
    }

    public async Task AddAsync(FamilyMember familyMember)
    {
        await _context.FamilyMembers.AddAsync(familyMember);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FamilyMember familyMember)
    {
        _context.FamilyMembers.Update(familyMember);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid familyMemberId)
    {
        var familyMember = await _context.FamilyMembers.FindAsync(familyMemberId);
        if (familyMember != null)
        {
            _context.FamilyMembers.Remove(familyMember);
            await _context.SaveChangesAsync();
        }
    }
}
