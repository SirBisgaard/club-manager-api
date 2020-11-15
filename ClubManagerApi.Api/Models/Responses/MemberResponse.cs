using System;

namespace ClubManagerApi.Api.Models.Responses
{
    public class MemberResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime FirstRegistered { get; set; }
    }
}