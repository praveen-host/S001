using DTO.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbAccess.Interface
{
    public interface IEntityRepository
    {
        public Task<Entity> GetEntity(int entityId);
        public Task<IEnumerable<Entity>> GetAllEntity();
        public Task<IEnumerable< int>> AddEntity(Entity entity);
        public Task<int> AddEntities(List<Entity> entities);
        public Task<int> UpdateEntity(Entity entity);
        public Task<int> UpdateEntities(List<Entity> entities);

    }
}
