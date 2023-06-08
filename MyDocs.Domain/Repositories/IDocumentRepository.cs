using MyDocs.Domain.Entities;

namespace MyDocs.Domain.Repositories;

public interface IDocumentRepository
{
    Task<Document> GetByIdAsync(Guid documentId);
    Task<IEnumerable<Document>> GetAllByFamilyMemberIdAsync(Guid familyMemberId);
    Task AddAsync(Document document);
    Task UpdateAsync(Document document);
    Task DeleteAsync(Guid documentId);
}
