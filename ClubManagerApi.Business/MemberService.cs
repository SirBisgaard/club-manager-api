
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using ClubManagerApi.Domain;
using ClubManagerApi.DataAccess;

namespace ClubManagerApi.Business
{
    internal class MemberService : IMemberService
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
            _logger.LogDebug("Creating a new member.");

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
            _logger.LogDebug($"Udating member with Id: {member.Id}.");

            return await _memberRepository.UpdateMember(member);
        }

        public async Task<bool> DeleteMember(int id)
        {
            _logger.LogDebug($"Deleting member with Id: {id}.");
            
            return await _memberRepository.DeleteMember(id);
        }
    }
}