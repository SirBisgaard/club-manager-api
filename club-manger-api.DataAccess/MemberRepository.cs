using club_manger_api.Domain;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace club_manger_api.DataAccess
{

    internal class MemberRepository : BaseRepository, IMemberRepository
    {

        private readonly ILogger<MemberRepository> _logger;

        public MemberRepository(ILogger<MemberRepository> logger)
        {
            _logger = logger;

            InitDatabase();
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            _logger.LogDebug($"Getting all members.");

            using (var connection = Connection)
            {
                await connection.OpenAsync();

                return await connection.QueryAsync<Member>("select * from Members");
            }
        }

        public async Task<Member> GetMember(int id)
        {
            _logger.LogDebug($"Getting member with Id: {id}.");

            using (var connection = Connection)
            {
                await connection.OpenAsync();

                return await connection.QuerySingleOrDefaultAsync<Member>("select * from Members where ID = @id", new
                {
                    id
                });
            }
        }

        public async Task<Member> CreateMember(Member member)
        {
            _logger.LogDebug("Creating a new member.");

            using (var connection = Connection)
            {
                await connection.OpenAsync();
                member.Id = (await connection.QueryAsync<int>(
                    @"INSERT INTO Members 
                    (Name, Mail, Active, DateOfBirth, FirstRegistered) VALUES 
                    (@Name, @Mail, @Active, @DateOfBirth, @FirstRegistered);
                    select last_insert_rowid()", member)).First();
            }
            return member;
        }

        public async Task<Member> UpdateMember(Member member)
        {
            _logger.LogDebug($"Updating member with Id: {member.Id}.");

            throw new NotImplementedException();
        }

        public async Task<bool> DeleteMember(int id)
        {
            _logger.LogDebug($"Member is deleted.");

            throw new NotImplementedException();
        }
    }
}