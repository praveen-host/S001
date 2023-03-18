using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Interface
{
    public interface IRoleRepository
    {
        public Task<Role> GetRole(int roleId);
        public Task<IEnumerable<Role>> GetRoles();
        public Task<int> AddRole(Role role);
        public Task<int> AddRoles(List<Role> roles);
        public Task<int> UpdateRole(Role role);
        public Task<int> UpdateRoles(List<Role> roles);
        
    }
}
