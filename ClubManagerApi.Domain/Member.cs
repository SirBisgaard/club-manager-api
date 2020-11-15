using System;

namespace ClubManagerApi.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime FirstRegistered { get; set; }
    }
}