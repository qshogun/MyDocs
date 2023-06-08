using AutoMapper;
using MyDocs.Domain.Entities;
using MyDocs.Domain.Repositories;
using MyDocs.Models.DTOs;

namespace MyDocs.Application.Services
{
    public class FamilyMemberService : IFamilyMemberService
    {
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IMapper _mapper;

        public FamilyMemberService(IFamilyMemberRepository familyMemberRepository, IMapper mapper)
        {
            _familyMemberRepository = familyMemberRepository ?? throw new ArgumentNullException(nameof(familyMemberRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<FamilyMemberDTO> AddFamilyMember(FamilyMemberDTO familyMemberDto)
        {
            var familyMember = _mapper.Map<FamilyMember>(familyMemberDto);

            await _familyMemberRepository.AddAsync(familyMember);

            familyMemberDto.FamilyMemberId = familyMember.Id;
            return familyMemberDto;
        }

        public async Task<FamilyMemberDTO> GetFamilyMember(Guid familyMemberId)
        {
            var familyMember = await _familyMemberRepository.GetByIdAsync(familyMemberId);
            if (familyMember == null)
                return null;

            return _mapper.Map<FamilyMemberDTO>(familyMember);
        }

        public async Task<List<FamilyMemberDTO>> GetAllFamilyMembers()
        {
            var familyMembers = await _familyMemberRepository.GetAllAsync();
            if (familyMembers == null)
                return new List<FamilyMemberDTO>();

            return _mapper.Map<List<FamilyMemberDTO>>(familyMembers);
        }

        public async Task UpdateFamilyMember(FamilyMemberDTO familyMemberDto)
        {
            var familyMember = await _familyMemberRepository.GetByIdAsync(familyMemberDto.FamilyMemberId);
            if (familyMember == null)
                throw new Exception("Family member not found");

            _mapper.Map(familyMemberDto, familyMember);
            await _familyMemberRepository.UpdateAsync(familyMember);
        }

        public async Task DeleteFamilyMember(Guid familyMemberId)
        {
            var familyMember = await _familyMemberRepository.GetByIdAsync(familyMemberId);
            if (familyMember == null)
                throw new Exception("Family member not found");

            await _familyMemberRepository.DeleteAsync(familyMemberId);
        }
    }
}
