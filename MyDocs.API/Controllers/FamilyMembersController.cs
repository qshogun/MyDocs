using Microsoft.AspNetCore.Mvc;
using MyDocs.Application.Services;
using MyDocs.Domain.Enums;
using MyDocs.Models.DTOs;

namespace MyDocs.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FamilyMembersController : ControllerBase
{
    private readonly IFamilyMemberService _familyMemberService;

    public FamilyMembersController(IFamilyMemberService familyMemberService)
    {
        _familyMemberService = familyMemberService ?? throw new ArgumentNullException(nameof(familyMemberService));
    }

    // POST api/familymembers
    [HttpPost]
    public async Task<IActionResult> AddFamilyMember([FromBody] FamilyMemberCreateDTO familyMemberCreateDTO)
    {
        if (familyMemberCreateDTO == null)
        {
            return BadRequest("Invalid family member data.");
        }

        // Convert strings to enums
        var genderEnum = Gender.FromName<Gender>(familyMemberCreateDTO.Gender);
        var relationshipEnum = Relationship.FromName<Relationship>(familyMemberCreateDTO.Relationship);

        // Create a FamilyMemberDTO and set its properties
        var familyMemberDTO = new FamilyMemberDTO
        {
            FirstName = familyMemberCreateDTO.FirstName,
            LastName = familyMemberCreateDTO.LastName,
            DateOfBirth = familyMemberCreateDTO.DateOfBirth,
            Gender = genderEnum, // Should work if Gender is a subclass of Enumeration
            Relationship = relationshipEnum // Should work if Relationship is a subclass of Enumeration
        };

        // Pass FamilyMemberDTO to the service
        await _familyMemberService.AddFamilyMember(familyMemberDTO);
        return Ok("Family member added successfully.");
    }

    [HttpGet]
    public async Task<IActionResult> GetAllFamilyMembers()
    {
        var familyMembers = await _familyMemberService.GetAllFamilyMembers();
        if (familyMembers == null)
            return NotFound();

        return Ok(familyMembers);
    }
}

