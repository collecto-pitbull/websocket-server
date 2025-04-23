using Microsoft.AspNetCore.SignalR;

namespace CollectoWebSockets.WebSockets
{
    public class ContributionHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            // Called when a client connects to the hub
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public async Task SendContribution(object contribution)
        {
            // Broadcast to all clients
            await Clients.All.SendAsync("ReceiveContribution", contribution);
        }

    }
}
