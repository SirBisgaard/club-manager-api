using System;

namespace club_manger_api.Domain
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public bool Active { get; set; }
        public DateTime FirstRegistered { get; set; }
    }
}