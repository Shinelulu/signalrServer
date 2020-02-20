using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeCommunicationServer.Hubs
{
    public class ChatHub :Hub
    {
        public ChatHub()
        {

        }
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("receiveMessage", DateTime.Now + "：已连接至服务端");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("receiveMessage", DateTime.Now + "：已断开与服务端的连接");
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("receiveMessage", DateTime.Now + $"：{message}");
        }
    }
}
