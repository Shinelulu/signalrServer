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

        [HttpPost]
        public async Task<IActionResult> PostApiResponse(object report)
        {
            await hubContext.Clients.All.SendAsync("receiveMessage", DateTime.Now + "：来自Web Api的接口调用");
            return Ok();
        }

        [HttpPost("task")]
        public async Task<IActionResult> PostTaskApi(object task)
        {
            await hubContext.Clients.Group("中间系统").SendAsync("receiveMessage", DateTime.Now + "：来自上级系统下发的任务", task);
            return Ok();
        }
    }
}