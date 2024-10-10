using BarcelonaBackEnd.Models;
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
        _logger.LogInformation($"Message received from {user}: {message}");
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }

    public async Task SendReadReceipt(string messageId, string username)
    {
        _logger.LogInformation($"Message read receipt for message id {messageId} from {username}");
        await Clients.All.SendAsync("ReceiveReadReceipt", messageId);
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation($"Client connected: {Context.ConnectionId}");
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception exception)
    {
        _logger.LogInformation($"Client disconnected: {Context.ConnectionId}");
        return base.OnDisconnectedAsync(exception);
    }

    public async Task NotifyReadReceipt(string messageId, string username)
    {
        await Clients.All.SendAsync("ReceiveReadReceipt", messageId, username);
    }

}
