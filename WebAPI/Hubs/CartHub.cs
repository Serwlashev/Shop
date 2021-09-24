using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace WebAPI.Hubs
{
    public class CartHub : BaseHub<string>
    {
        public override async Task OnConnectedAsync()
        {
            if(Count == 0)
            {
                Add("Server", Context.ConnectionId);
            }
            else
            {
                var userId = Guid.NewGuid().ToString();
                Add(userId, Context.ConnectionId);
            }

            await Clients.Client(Context.ConnectionId).SendAsync("newClientConnected", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            Remove(GetUserByConnection(Context.ConnectionId), Context.ConnectionId);
            await Clients.Client(Context.ConnectionId).SendAsync("clientDisconnected", Context.ConnectionId);
        }

        public async Task SendMessage(string userId, string message)
        {
            var connections = GetConnections(userId);
            
            foreach(var connection in connections)
            {
                await Clients.Client(connection).SendAsync("newMessage", message);
            }
        }
    }
}
