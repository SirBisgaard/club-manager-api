using System.Collections.Generic;
using System.Threading.Tasks;
using ClubManagerApi.Domain;

namespace ClubManagerApi.DataAccess
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
