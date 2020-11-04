using ClubManagerApi.Domain;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data;

namespace ClubManagerApi.DataAccess
{

    internal class MemberRepository : BaseRepository, IMemberRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILogger<MemberRepository> _logger;

        public MemberRepository(IDbConnection connection, ILogger<MemberRepository> logger) : base(connection)
        {
            _connection = connection;
            _logger = logger;
        }

        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            _logger.LogDebug($"Getting all members.");

            return await _connection.QueryAsync<Member>(@"
                SELECT 
                    * 
                FROM Members");
        }

        public async Task<Member> GetMember(int id)
        {
            _logger.LogDebug($"Getting member with Id: {id}.");

            return await _connection.QuerySingleOrDefaultAsync<Member>(@"
                SELECT 
                    * 
                FROM Members 
                WHERE ID = @id",
                new { id });
        }

        public async Task<Member> CreateMember(Member member)
        {
            _logger.LogDebug("Creating a new member.");

            member.Id = (await _connection.QueryAsync<int>(@"
                INSERT INTO Members 
                    (Name, 
                    Mail, 
                    Active, 
                    DateOfBirth, 
                    FirstRegistered) 
                VALUES 
                    (@Name, 
                    @Mail, 
                    @Active, 
                    @DateOfBirth, 
                    @FirstRegistered);
                SELECT last_insert_rowid()",
                member)).First();

            return member;
        }

        public async Task<Member> UpdateMember(Member member)
        {
            _logger.LogDebug($"Updating member with Id: {member.Id}.");

            await _connection.ExecuteAsync(@"
                UPDATE Members 
                SET 
                    Name = @Name, 
                    Mail = @Mail, 
                    Active = @Active, 
                    DateOfBirth = @DateOfBirth, 
                    FirstRegistered = @FirstRegistered",
                member);

            return member;
        }

        public async Task<bool> DeleteMember(int id)
        {
            _logger.LogDebug($"Member is deleted.");

            await _connection.ExecuteAsync(@"
                DELETE FROM Members 
                WHERE Id = @id",
                new { id });

            return true;
        }
    }
}