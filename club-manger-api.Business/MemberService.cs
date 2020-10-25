
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using club_manger_api.Domain;
using System.Threading.Tasks;
using System;
using club_manger_api.DataAccess;

namespace club_manger_api.Business
{
    public class MemberService : IMemberService
    {
        private readonly ILogger<MemberService> _logger;
        private readonly IMemberRepository _memberRepository;

        public MemberService(ILogger<MemberService> logger, IMemberRepository memberRepository)
        {
            _logger = logger;
            _memberRepository = memberRepository;
        }

        public async Task<Member> CreateMember(Member member)
        {
            return await _memberRepository.CreateMember(member);
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            _logger.LogDebug("Getting all members.");

            return await _memberRepository.GetAllMembers();
        }

        public async Task<Member> GetMember(int id)
        {
            _logger.LogDebug($"Getting member with Id: {id}.");
            
            return await _memberRepository.GetMember(id);
        }

        public async Task<Member> UpdateMember(Member member)
        {
            return await _memberRepository.UpdateMember(member);
        }

        public async Task<bool> DeleteMember(int id)
        {
            return await _memberRepository.DeleteMember(id);
        }
    }
}