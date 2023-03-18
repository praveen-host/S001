using DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly AppConfig appConfig;
        public ValuesController(IOptions<AppConfig> _appConfig)
        {
            this.appConfig = _appConfig.Value;
        }

        [HttpGet]
        [Route("GetAppConfig")]
        public IActionResult GetAppConfig()
        {
            return Ok(appConfig);
        }
    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MessageHandler : Hub
    {
        private readonly Dictionary<string, UserDetails> connectedUsers = new Dictionary<string, UserDetails>();
        public override Task OnConnectedAsync()
        {


            connectedUsers.Add(Context.ConnectionId,
                new UserDetails
                {
                    ConnectionId = Context.ConnectionId,
                    UserName = Context.User.FindFirst("UserName").Value
                });

            Clients.All.SendAsync("userJoined", new
            {
                connectionId= Context.ConnectionId,
                username = Context.User.FindFirst("UserName").Value,
                firstName= Context.User.FindFirst("FName").Value,
                lastName=Context.User.FindFirst("LName").Value,

            });
            return Task.FromResult(base.OnConnectedAsync());

        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("userLeft", new
            {
                ConnectionId = Context.ConnectionId
            });
            
            return base.OnDisconnectedAsync(exception);
        }


        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("newMessage", "anonymous", message);
        }
         
    }

    public class Message
    {
        public string clientuniqueid { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        public string type { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
    }

    public class UserDetails
    {
        public string UserName { get; set; }
        public string ConnectionId { get; set; }
    }
}
