using DbAccess.Interface;
using DTO.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {

        private readonly IRoleRepository roleRepo;
        public RolesController(IRoleRepository roleRepo)
        {
            this.roleRepo = roleRepo;
        }

        [HttpGet]
        [Route("GetRole/{roleId}")]
        public async Task<IActionResult> GetRoles(int roleId)
        {
            try
            {
                var roles = await roleRepo.GetRole(roleId);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await roleRepo.GetRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddRole")]
        public async Task<IActionResult> AddRole([FromBody]Role role)
        {
            try
            {
                var id = await roleRepo.AddRole(role);
                return Ok(id);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("AddRoles")]
        public async Task<IActionResult> AddRoles([FromBody] List<Role> roles)
        {
            try
            {
                var id = await roleRepo.AddRoles(roles);
                return Ok(id);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("AddRole")]
        public async Task<IActionResult> UpdateRole([FromBody] Role role)
        {
            try
            {
                var id = await roleRepo.UpdateRole(role);
                return Ok(id);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

    }
}
