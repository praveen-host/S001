using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Interface
{
    public interface IUserRepository
    {
        public Task<User> GetRole(int roleId);
        public Task<IEnumerable<User>> GetRoles();
        public Task<int> AddUser(User user);
        public Task<User> GetUser(int userId);
        public Task<User> ValidateUser(string userName, string password);

        public Task<int> AddRoles(List<User> users);
        public Task<int> UpdateRole(User role);
        public Task<int> UpdateRoles(List<User> users);
    }
}
