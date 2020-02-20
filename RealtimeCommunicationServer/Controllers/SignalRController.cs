using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealtimeCommunicationServer.Hubs;

namespace RealtimeCommunicationServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignalRController : ControllerBase
    {
        private readonly IHubContext<ChatHub> hubContext;

        public SignalRController(IHubContext<ChatHub> context)
        {
            hubContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetApiResponse()
        {
            await hubContext.Clients.All.SendAsync("receiveMessage", DateTime.Now + "：来自Web Api的接口调用");
            return Ok();
        }
    }
}