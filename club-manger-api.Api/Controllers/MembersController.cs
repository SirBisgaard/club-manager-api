using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using club_manger_api.Business;

namespace club_manger_api.Api.Controllers
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

            return Ok(await _memberService.GetAllMembers());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            _logger.LogDebug($"Getting member with Id: {id}.");

            var member = await _memberService.GetMember(id);

            if (member == null)
            {
                _logger.LogDebug($"Did not find memeber.");

                return NotFound();
            }

            return Ok(member);
        }
    }
}
