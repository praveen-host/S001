using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitController : ControllerBase
    {
        private readonly AppConfig appConfig;
        public InitController(IOptions<AppConfig> _appConfig)
        {
            this.appConfig = _appConfig.Value;
        }
        // POST api/<InitController>
        [HttpGet("Test")]
        public void GetTest()
        {
            Ok(this.appConfig);
        }

    }
}
