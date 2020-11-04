using System.Collections.Generic;
using System.Threading.Tasks;
using ClubManagerApi.Domain;

namespace ClubManagerApi.DataAccess
{
    public interface IMemberRepository
    {
        Task<IEnumerable<Member>> GetAllMembers();
        Task<Member> GetMember(int id);
        Task<Member> CreateMember(Member member);
        Task<Member> UpdateMember(Member member);
        Task<bool> DeleteMember(int id);
    }
}
