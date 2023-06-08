using MyDocs.Models.DTOs;

namespace MyDocs.Application.Services;

public interface IDocumentService
{
    Task<DocumentDTO> AddDocumentToFamilyMember(DocumentDTO document, Guid familyMemberId);
    Task<DocumentDTO> GetDocument(Guid documentId);
    Task<List<DocumentDTO>> GetAllDocumentsForFamilyMember(Guid familyMemberId);
    Task UpdateDocument(DocumentDTO document);
    Task DeleteDocument(Guid documentId);
}
