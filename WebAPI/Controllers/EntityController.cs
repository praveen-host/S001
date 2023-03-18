using DbAccess.Interface;
using DTO.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntityController : ControllerBase
    {

        private readonly IEntityRepository entityRepository;

        public EntityController(IEntityRepository entityRepository)
        {
            this.entityRepository = entityRepository;
        }

        [HttpGet]
        [Route("GetEntity/{entityId}")]
        public async Task<IActionResult> GetEntity(int entityId)
        {
            var response = await entityRepository.GetEntity(entityId);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetAllEntity")]
        public async Task<IActionResult> GetAllEntity()
        {
            var response = await entityRepository.GetAllEntity();
            return Ok(response);
        }

        [HttpPost]
        [Route("AddEntity")]
        public async Task<IActionResult> AddEntity(Entity entity)
        {
            var response =await entityRepository.AddEntity(entity);
            return Ok(response);
        }
    }
}
