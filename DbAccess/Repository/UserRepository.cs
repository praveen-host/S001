using Dapper;
using DbAccess.Interface;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace DbAccess.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext context;
        public UserRepository(DapperContext context)
        {
            this.context = context;
        }
        public Task<int> AddUser(User user)
        {

            var query = "INSERT INTO USERS(USER_NAME,PASSWORD,STATUS) VALUES (@userName,@password,1)";
            var parameters = new { userName = user.UserName, password = GetMD5HashPassword(user.Password) };

            using (var conn = context.CreateConnection())
            {
                return conn.ExecuteAsync(query, parameters);
            }
        }

        public Task<User> GetUser(int userId)
        {
            var query = "SELECT  USER_ID UserId,USER_NAME UserName FROM USERS WHERE USER_ID=@userId;";
            var parameters = new
            {
                userId = userId
            };

            using (var conn = context.CreateConnection())
            {
                return conn.QueryFirstOrDefaultAsync<User>(query, parameters);
            }
        }

        public Task<User> ValidateUser(string userName,string password) {
            var query = "SELECT  USER_ID as UserId,USER_NAME as UserName FROM USERS WHERE USER_NAME=@userName and password=@password;";
            var parameters = new
            {
                userName = userName,
                password= GetMD5HashPassword(password)
            };

            using (var conn = context.CreateConnection())
            {
                return conn.QueryFirstOrDefaultAsync<User>(query, parameters);
            }
        }

        public Task<int> AddRoles(List<User> users)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetRole(int roleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetRoles()
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRole(User role)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateRoles(List<User> users)
        {
            throw new NotImplementedException();
        }


        private  string GetMD5HashPassword(string password)
        {
            using (var md5Hash = MD5.Create())
            {
                // Byte array representation of source string
                var sourceBytes = Encoding.UTF8.GetBytes(password);

                // Generate hash value(Byte Array) for input data
                var hashBytes = md5Hash.ComputeHash(sourceBytes);

                // Convert hash byte array to string
                var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

                // Output the MD5 hash
                return hash;
            }

        }
    }
}
