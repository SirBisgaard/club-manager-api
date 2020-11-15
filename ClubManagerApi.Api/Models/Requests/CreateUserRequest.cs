using System;

namespace ClubManagerApi.Api.Models.Requests
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }
}