using System.Collections.Generic;
using System.Threading.Tasks;
using ClubManagerApi.Domain;

namespace ClubManagerApi.Business
{
    public interface IMemberService
    {
        Task<IEnumerable<Member>> GetAllMembers();
        Task<Member> GetMember(int id);
        Task<Member> UpdateMember(Member member);
        Task<Member> CreateMember(Member member);
        Task<bool> DeleteMember(int id);
    }
}
