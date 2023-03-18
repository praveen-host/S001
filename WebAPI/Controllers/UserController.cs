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
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        [HttpPost]
        [Route("AddUser")]
        public async Task<IActionResult> AddUser(User user)
        {
            var response = await userRepository.AddUser(user);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetUser/{userId}")]
        public async Task<IActionResult> GetUser(int userId)
        {
            var response = await userRepository.GetUser(userId);
            return Ok(response);
        }
    }
}
