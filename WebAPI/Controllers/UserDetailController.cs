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
    public class UserDetailController : ControllerBase
    {

        private readonly IUserDetailRepository userDetailRepository;

        public UserDetailController(IUserDetailRepository userDetailRepository)
        {
            this.userDetailRepository = userDetailRepository;
        }

        [HttpGet]
        [Route("GetUserDetails/{userId}")]
        public async Task<IActionResult> GetEntity(int userId)
        {
            var response = await userDetailRepository.GetUserDetail(userId);
            return Ok(response);
        }
        [HttpPost]
        [Route("AddUserDetail")]
        public async Task<IActionResult> AddUserDetail(UserDetail userDetail,int userId)
        {
            
            var response = await userDetailRepository.AddUserDetail(userDetail,userId);
            return Ok(response);
        }
    }
}
