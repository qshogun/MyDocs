using AutoMapper;
using MyDocs.Domain.Entities;
using MyDocs.Domain.Repositories;
using MyDocs.Models.DTOs;

namespace MyDocs.Application.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;
    private readonly IFamilyMemberRepository _familyMemberRepository;
    private readonly IMapper _mapper;

    public DocumentService(IDocumentRepository documentRepository, IFamilyMemberRepository familyMemberRepository, IMapper mapper)
    {
        _documentRepository = documentRepository ?? throw new ArgumentNullException(nameof(documentRepository));
        _familyMemberRepository = familyMemberRepository ?? throw new ArgumentNullException(nameof(familyMemberRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<DocumentDTO> AddDocumentToFamilyMember(DocumentDTO documentDto, Guid familyMemberId)
    {
        var familyMember = await _familyMemberRepository.GetByIdAsync(familyMemberId);
        if (familyMember == null)
            throw new Exception("Family member not found");

        var document = _mapper.Map<Document>(documentDto);
        document.AssociatedFamilyMember = familyMember;

        await _documentRepository.AddAsync(document);

        documentDto.DocumentId = document.Id;
        return documentDto;
    }

    public async Task<DocumentDTO> GetDocument(Guid documentId)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);
        if (document == null)
            return null;

        return _mapper.Map<DocumentDTO>(document);
    }

    public async Task<List<DocumentDTO>> GetAllDocumentsForFamilyMember(Guid familyMemberId)
    {
        var documents = await _documentRepository.GetAllByFamilyMemberIdAsync(familyMemberId);
        if (documents == null)
            return new List<DocumentDTO>();

        return _mapper.Map<List<DocumentDTO>>(documents);
    }

    public async Task UpdateDocument(DocumentDTO documentDto)
    {
        var document = await _documentRepository.GetByIdAsync(documentDto.DocumentId);
        if (document == null)
            throw new Exception("Document not found");

        _mapper.Map(documentDto, document);
        await _documentRepository.UpdateAsync(document);
    }

    public async Task DeleteDocument(Guid documentId)
    {
        var document = await _documentRepository.GetByIdAsync(documentId);
        if (document == null)
            throw new Exception("Document not found");

        await _documentRepository.DeleteAsync(documentId);
    }
}
