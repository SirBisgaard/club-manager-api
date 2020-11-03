using System;

namespace club_manger_api.Api.Models.Requests
{
    public class CreateMemberRequest
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime FirstRegistered { get; set; }
    }
}