using Microsoft.AspNetCore.SignalR;

namespace OperationService.Hubs
{
    public class GameHub(ILogger<GameHub> _logger) : Hub
    {
        //public Task Connect(string username)
        //{
        //    var id = Context.ConnectionId;
        //    _logger.LogInformation("user with id '{Id}': {Username}", id, username);
        //    return Task.CompletedTask;
        //}

        //public async Task AddToGroup(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        //    await Clients.Group(groupName).SendAsync("Send", $"{Context.ConnectionId} has joined the group {groupName}.");
        //}

        //public Task NotificationForAll(string user, string message)
        //{
        //    return Task.CompletedTask;
        //}

        public async Task SendMessage(string user, string message)
            => await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
