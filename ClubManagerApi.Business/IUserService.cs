using System.Collections.Generic;
using System.Threading.Tasks;
using ClubManagerApi.Domain;

namespace ClubManagerApi.Business
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> UpdateUser(User user);
        Task<User> CreateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
