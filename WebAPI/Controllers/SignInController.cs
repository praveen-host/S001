using DbAccess.Interface;
using DTO.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        private readonly IUserRepository userRepository;
        private readonly IUserDetailRepository userDetailRepository;

        public SignInController(IConfiguration config, IUserRepository userRepository, IUserDetailRepository userDetailRepository)
        {
            _configuration = config;
            this.userRepository = userRepository;
            this.userDetailRepository = userDetailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            var validUser = await userRepository.ValidateUser(user.UserName, user.Password);
            if (validUser != null)
            {
                var detail = await userDetailRepository.GetUserDetail(validUser.UserId);
                var claims = new[] {
                        //new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        //new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        //new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        //new Claim("UserName",validUser.UserName),
                        new Claim("FName", detail.FName),
                        new Claim("MName",  detail.MName),
                        new Claim("LName",  detail.MName),
                        new Claim("Gender",  detail.Gender)
                    };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    username = validUser.UserName,
                    FName = detail.FName,
                    MName = detail.MName,
                    LName = detail.LName,
                    Gender = detail.Gender

                });
            }
            else {
                return BadRequest("Invalid username/password");
            }
            
        }

    }
}
