using AutoMapper;
using MyDocs.Domain.Entities;
using MyDocs.Models.DTOs;

namespace MyDocs.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<Document, DocumentDTO>().ReverseMap();
        CreateMap<FamilyMemberDTO, FamilyMember>().ReverseMap();
    }
}
