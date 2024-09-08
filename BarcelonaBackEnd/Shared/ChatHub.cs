namespace BarcelonaBackEnd.Shared
{
    using Microsoft.AspNetCore.SignalR;
    public class ChatHub : Hub
    {
        private readonly ILogger<ChatHub> _logger;

        public ChatHub(ILogger<ChatHub> logger)
        {
            _logger = logger;
        }
        public async Task SendMessage(string user, string message)
        {
            var messageObject = new
            {
                User = user,
                Message = message
            };

            _logger.LogInformation("Received message from {User}: {Message}", user, message);

            await Clients.All.SendAsync("ReceiveMessage", messageObject);
        }
    }
}

