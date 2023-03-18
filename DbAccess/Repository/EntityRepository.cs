using Dapper;
using DbAccess.Interface;
using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbAccess.Repository
{
    public class EntityRepository : IEntityRepository
    {
        private readonly DapperContext context;
        public EntityRepository(DapperContext context)
        {
            this.context = context;
        }
        public Task<int> AddEntities(List<Entity> entities)
        {
            throw new NotImplementedException();

        }

        public Task<IEnumerable<int>> AddEntity(Entity entity)
        {
            var query = "INSERT INTO ENTITIES(FNAME,MNAME,LNAME,GENDER,DOB,DOA,MOBILENO,ALTERNATENO,EMERGENCY_CONTACT_NO) VALUES  (@fName,@mName,@lName,@gender,@dob,@doa,@mobileNo,@alternateNo,@emergencyNo);" +
            "SELECT LAST_INSERT_ID();";
            
            
            var parameters = new
            {
                fName = entity.FName,
                mName = entity.MName,
                lName = entity.LName,
                gender = entity.Gender,
                dob = entity.DOB,
                doa = entity.DOA,
                mobileNo = entity.MobileNo,
                alternateNo = entity.AlternateNo,
                emergencyNo = entity.EmergencyContactNo
            };

            using (var conn = context.CreateConnection())
            {                  
                return conn.QueryAsync<int>(query, parameters); 
            }
        }

        public Task<IEnumerable<Entity>> GetAllEntity()
        {
            var query = "SELECT ENTITY_ID EntityId,  FNAME,MNAME,LNAME,GENDER,DOB,DOA,MOBILENO,ALTERNATENO,EMERGENCY_CONTACT_NO EmergencyContactNo FROM ENTITIES ;";
             
            using (var conn = context.CreateConnection())
            {
                return conn.QueryAsync<Entity>(query);
            }
        }

        public Task<Entity> GetEntity(int entityId)
        {
            var query = "SELECT  ENTITY_ID EntityId,FNAME,MNAME,LNAME,GENDER,DOB,DOA,MOBILENO,ALTERNATENO,EMERGENCY_CONTACT_NO EmergencyContactNo FROM ENTITIES WHERE ENTITY_ID=@entityId;";
            var parameters = new
            {
                entityId =entityId
            };

            using (var conn = context.CreateConnection())
            {
                return conn.QueryFirstOrDefaultAsync<Entity>(query, parameters);
            }
        }

        public Task<int> UpdateEntities(List<Entity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateEntity(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
