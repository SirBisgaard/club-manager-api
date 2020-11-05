using ClubManagerApi.Domain;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using System.Data;

namespace ClubManagerApi.DataAccess
{

    internal class UserRepository : BaseRepository, IUserRepository
    {
        private readonly IDbConnection _connection;
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(IDbConnection connection, ILogger<UserRepository> logger) : base(connection)
        {
            _connection = connection;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            _logger.LogDebug($"Getting all users.");

            return await _connection.QueryAsync<User>(@"
                SELECT 
                    * 
                FROM Users
                WHERE Deleted IS NULL");
        }

        public async Task<User> GetUser(int id)
        {
            _logger.LogDebug($"Getting user with Id: {id}.");

            return await _connection.QuerySingleOrDefaultAsync<User>(@"
                SELECT 
                    * 
                FROM Users 
                WHERE ID = @id AND Deleted IS NULL",
                new { id });
        }

        public async Task<User> CreateUser(User user)
        {
            _logger.LogDebug("Creating a new user.");

            user.Id = (await _connection.QueryAsync<int>(@"
                INSERT INTO Users 
                    (Name, 
                    Mail, 
                    Password,
                    Created) 
                VALUES 
                    (@Name, 
                    @Mail, 
                    @Password,
                    DATETIME('now'));
                SELECT last_insert_rowid()",
                user)).First();

            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _logger.LogDebug($"Updating user with Id: {user.Id}.");

            await _connection.ExecuteAsync(@"
                UPDATE Users 
                SET 
                    Name = @Name, 
                    Mail = @Mail
                WHERE Id = @Id",
                user);

            return user;
        }

        public async Task<bool> DeleteUser(int id)
        {
            _logger.LogDebug($"User is deleted.");

            await _connection.ExecuteAsync(@"
                UPDATE Users 
                SET 
                    Deleted = DATETIME('now')
                WHERE Id = @id",
                new { id });

            return true;
        }
    }
}