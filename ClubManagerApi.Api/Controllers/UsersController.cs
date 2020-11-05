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
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<UsersController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogDebug("Getting all users.");

            var users = await _userService.GetAllUsers();

            return Ok(users.Select(MapToResponse));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            _logger.LogDebug($"Getting user with Id: {id}.");

            var user = await _userService.GetUser(id);

            if (user == null)
            {
                _logger.LogDebug($"Did not find memeber with Id: {id}.");

                return NotFound();
            }

            return Ok(MapToResponse(user));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest user)
        {
            _logger.LogDebug($"Creating new User.");

            return Ok(MapToResponse(await _userService.CreateUser(new User
            {
                Name = user.Name,
                Mail = user.Mail,
                Password = user.Password
            })));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, [FromBody] UpdateUserRequest user)
        {
            _logger.LogDebug($"Updating User Id={id}.");

            return Ok(MapToResponse(await _userService.UpdateUser(new User
            {
                Id = id,
                Name = user.Name,
                Mail = user.Mail
            })));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            _logger.LogDebug($"Deleting user ID={id}.");

            return Ok(await _userService.DeleteUser(id));
        }

        private static UserResponse MapToResponse(User user)
        {
            return new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Mail = user.Mail
            };
        }
    }
}
