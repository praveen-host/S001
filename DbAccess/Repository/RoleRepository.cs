using Dapper;
using DbAccess.Interface;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbAccess.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperContext context;
        public RoleRepository(DapperContext context)
        {
            this.context = context;
        }

        public Task<IEnumerable<Role>> GetRoles()
        {
            var query = "SELECT ROLE_ID RoleId,ROLE_NAME RoleName,DESCRIPTION Description,CREATEDDATE CreatedDate,LASTMODIFIEDDATE LastModifiedDate from ROLES";
            using (var connection = context.CreateConnection())
            {
                return connection.QueryAsync<Role>(query);
            }
        }

        public Task<int> AddRole(Role role)
        {
            var query = "INSERT INTO ROLES(ROLE_NAME,DESCRIPTION) VALUES (@roleName,@description)";
            var parameters = new { roleName = role.RoleName, description = role.Description };

            using (var conn = context.CreateConnection())
            {
                return conn.ExecuteAsync(query, parameters);
            }
        }

        public Task<int> AddRoles(List<Role> roles)
        {
            var query = "INSERT INTO ROLES(ROLE_NAME,DESCRIPTION) VALUES (@roleName,@description)";
            var parameters = new List<object>();
            foreach (var item in roles)
            {
                parameters.Add(new { roleName = item.RoleName, description = item.Description });
            }

            using (var conn = context.CreateConnection())
            {
                return conn.ExecuteAsync(query, parameters);
            }
        }

        public async Task<Role> GetRole(int roleId)
        {
            var query = "SELECT ROLE_ID RoleId,ROLE_NAME RoleName,DESCRIPTION Description,CREATEDDATE CreatedDate,LASTMODIFIEDDATE LastModifiedDate from ROLES where ROLE_ID=@roleId";
            var parameters = new { roleId = roleId };

            using (var connection = context.CreateConnection())
            {
                var roles = await connection.QueryFirstOrDefaultAsync<Role>(query, parameters);
                return roles;
            }

        }

        public Task<int> UpdateRole(Role role)
        {
            var query = "UPDATE ROLES SET ROLE_NAME=@roleName,DESCRIPTION=@description,LASTMODIFIEDDATE=CURRENT_TIME where ROLE_ID=@roleId and LASTMODIFIEDDATE=@lastModifiedDate";
            var parameters = new { roleName = role.RoleName, description = role.Description, roleId = role.RoleId, lastModifiedDate = role.LastmodifiedDate };

            using (var conn = context.CreateConnection())
            {
                return conn.ExecuteAsync(query, parameters);
            }
        }

        public Task<int> UpdateRoles(List<Role> roles)
        {
            throw new NotImplementedException();
        }
    }
}
