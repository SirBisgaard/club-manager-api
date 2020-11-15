using System;

namespace ClubManagerApi.Api.Models.Requests
{
    public class UpdateMemberRequest
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime FirstRegistered { get; set; }
    }
}