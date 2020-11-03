using System.Collections.Generic;
using System.Threading.Tasks;
using club_manger_api.Domain;

namespace club_manger_api.DataAccess
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
