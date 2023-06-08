//using Microsoft.EntityFrameworkCore;
//using MyDocs.Domain.Entities;
//using MyDocs.Domain.Repositories;
//using MyDocs.Infrastructure.DB;

//namespace MyDocs.Infrastructure.Repositories;

//public class DocumentRepository : IDocumentRepository
//{
//    private readonly MyDocsDbContext _context;

//    public DocumentRepository(MyDocsDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<Document> GetByIdAsync(Guid id)
//    {
//        return await _context.Documents.FindAsync(id);
//    }

//    public async Task<IEnumerable<Document>> GetAllAsync()
//    {
//        return await _context.Documents.ToListAsync();
//    }

//    public async Task AddAsync(Document document)
//    {
//        await _context.Documents.AddAsync(document);
//        await _context.SaveChangesAsync();
//    }

//    public async Task UpdateAsync(Document document)
//    {
//        _context.Documents.Update(document);
//        await _context.SaveChangesAsync();
//    }

//    public async Task DeleteAsync(Guid documentId)
//    {
//        var document = await _context.Documents.FindAsync(documentId);
//        if (document != null)
//        {
//            _context.Documents.Remove(document);
//            await _context.SaveChangesAsync();
//        }
//    }

//    public async Task SaveChangesAsync()
//    {
//        await _context.SaveChangesAsync();
//    }

//    public async Task<IEnumerable<Document>> GetAllByFamilyMemberIdAsync(Guid familyMemberId)
//    {
//        return await _context.Documents
//            .Where(document => document.AssociatedFamilyMember.Id == familyMemberId)
//            .ToListAsync();
//    }
//}
