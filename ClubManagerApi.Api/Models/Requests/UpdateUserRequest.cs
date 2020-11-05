using System;

namespace ClubManagerApi.Api.Models.Requests
{
    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public string Mail { get; set; }
    }
}