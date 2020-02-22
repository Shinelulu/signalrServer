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

        public async Task ConfirmLogin(string userName, string type)
        {
            Members.AddMember(userName, Context.ConnectionId);
            await Groups.AddToGroupAsync(Context.ConnectionId, type);
            await Clients.Caller.SendAsync("receiveMessage", DateTime.Now + $"：【{type}】用户【{userName}】已连接至工具管理系统");
        }

        public async Task ConfirmLogout(string userName, string type)
        {
            Members.RemoveMember(userName);
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, type);
            await Clients.Caller.SendAsync("closeConnection", DateTime.Now + $"：【{type}】用户【{userName}】退出工具管理系统");
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("receiveMessage", DateTime.Now + $"：{message}");
            
        }
    }
}
