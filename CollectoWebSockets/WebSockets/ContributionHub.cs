using CollectoWebSockets.DTO;
using CollectoWebSockets.Services;
using Microsoft.AspNetCore.SignalR;

namespace CollectoWebSockets.WebSockets
{
    public class ContributionHub : Hub
    {
        private readonly ContributionRepository _contributionRepository;

        public ContributionHub(ContributionRepository contributionRepository)
        {
            _contributionRepository = contributionRepository;
        }

        public override async Task OnConnectedAsync()
        {
            // Called when a client connects to the hub
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            await Clients.All.SendAsync("UserConnected", Context.ConnectionId);
            await base.OnConnectedAsync();
        }

        public async Task SendContribution(AddContributionDTO contributionDTO)
        {
            Console.WriteLine($"Received contribution from {contributionDTO.UserName} with balance {contributionDTO.Balance}");
            await Clients.All.SendAsync("ReceiveContribution", $"Received contribution from {contributionDTO.UserName} with balance {contributionDTO.Balance}");
            
            try
            {       
                await Clients.All.SendAsync("ReceiveContribution", contributionDTO);
                await _contributionRepository.AddContributionAsync(contributionDTO);
                // Broadcast to all client

            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                Console.WriteLine($"Error: {ex.Message}");
                await Clients.Caller.SendAsync("Error", ex.Message);

            }

        }
    }
}
