using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ClubManagerApi.Business;
using ClubManagerApi.Api.Models.Responses;
using System.Linq;
using ClubManagerApi.Api.Models.Requests;
using ClubManagerApi.Domain;

namespace ClubManagerApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembersController : ControllerBase
    {
        private readonly ILogger<MembersController> _logger;
        private readonly IMemberService _memberService;

        public MembersController(ILogger<MembersController> logger, IMemberService memberService)
        {
            _logger = logger;
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            _logger.LogDebug("Getting all members.");

            var members = await _memberService.GetAllMembers();

            return Ok(members.Select(MapToResponse));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMember([FromRoute] int id)
        {
            _logger.LogDebug($"Getting member with Id: {id}.");

            var member = await _memberService.GetMember(id);

            if (member == null)
            {
                _logger.LogDebug($"Did not find memeber with Id: {id}.");

                return NotFound();
            }

            return Ok(MapToResponse(member));
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberRequest member)
        {
            _logger.LogDebug($"Creating new Member.");

            return Ok(await _memberService.CreateMember(new Member
            {
                Name = member.Name,
                Mail = member.Mail,
                Active = member.Active,
                DateOfBirth = member.DateOfBirth,
                FirstRegistered = member.FirstRegistered
            }));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMember([FromRoute] int id, [FromBody] UpdateMemberRequest member)
        {
            _logger.LogDebug($"Updating Member Id={id}.");

            return Ok(await _memberService.UpdateMember(new Member
            {
                Id = id,
                Name = member.Name,
                Mail = member.Mail,
                Active = member.Active,
                DateOfBirth = member.DateOfBirth,
                FirstRegistered = member.FirstRegistered
            }));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMember([FromRoute] int id)
        {
            _logger.LogDebug($"Deleting member ID={id}.");

            return Ok(await _memberService.DeleteMember(id));
        }

        private static MemberResponse MapToResponse(Member member)
        {
            return new MemberResponse
            {
                Id = member.Id,
                Name = member.Name,
                Mail = member.Mail,
                Active = member.Active,
                DateOfBirth = member.DateOfBirth,
                FirstRegistered = member.FirstRegistered
            };
        }
    }
}
