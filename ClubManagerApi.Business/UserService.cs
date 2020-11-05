
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using ClubManagerApi.Domain;
using ClubManagerApi.DataAccess;

namespace ClubManagerApi.Business
{
    internal class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _userRepository;

        public UserService(ILogger<UserService> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            _logger.LogDebug("Getting all users.");

            return await _userRepository.GetAllUsers();
        }

        public async Task<User> GetUser(int id)
        {
            _logger.LogDebug($"Getting user with Id: {id}.");

            return await _userRepository.GetUser(id);
        }

        public async Task<User> UpdateUser(User user)
        {
            _logger.LogDebug($"Udating user with Id: {user.Id}.");

            return await _userRepository.UpdateUser(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            _logger.LogDebug($"Deleting user with Id: {id}.");
            
            return await _userRepository.DeleteUser(id);
        }
    }
}