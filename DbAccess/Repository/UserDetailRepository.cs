using Dapper;
using DbAccess.Interface;
using DTO.Entity;
using System.Threading.Tasks;

namespace DbAccess.Repository
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly DapperContext context;
        public UserDetailRepository(DapperContext context)
        {
            this.context = context;
        }
         
        public Task<int> AddUserDetail(UserDetail userDetail,int updatedId)
        {
            var query = "INSERT INTO USER_DETAILS(USER_ID,FNAME,MNAME,LNAME,GENDER,CREATEDBY_ID,LASTUPDATEDBY_ID) VALUES (@userId,@fname,@mname,@lname,@gender,@updatedId,@updatedId)";
            var parameters = new { userId= userDetail.UserId,fname= userDetail.FName,mname= userDetail.MName,lname= userDetail.FName,gender= userDetail.Gender,updatedId=updatedId};

            using (var conn = context.CreateConnection())
            {
                return conn.ExecuteAsync(query, parameters);
            }
        }

        public Task<UserDetail> GetUserDetail(int userId)
        {
            var query = "SELECT  USER_ID UserId,FNAME,MNAME,LNAME,GENDER FROM USER_DETAILS WHERE USER_ID=@userId;";
            var parameters = new
            {
                userId = userId
            };

            using (var conn = context.CreateConnection())
            {
                return conn.QueryFirstOrDefaultAsync<UserDetail>(query, parameters);
            }
        }
    }
}
