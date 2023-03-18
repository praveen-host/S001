using DTO.Entity;
using System.Threading.Tasks;

namespace DbAccess.Interface
{
    public interface IUserDetailRepository
    {
        public Task<UserDetail> GetUserDetail(int userId); 
        public Task<int> AddUserDetail(UserDetail userDetail, int updatedId);
    }
}
