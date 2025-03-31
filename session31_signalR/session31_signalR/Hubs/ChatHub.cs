using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task sendPrivateMessage(string user, string message)
    {
        Console.WriteLine("sendPrivateMessage");
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
    public async Task SendGroupMessage(string group, string user, string message)
    {
        // gửi event đến clients trong group
        Console.WriteLine("SendGroupMessage");
        await Clients.Group(group).SendAsync("ReceiveMessageGroup", group, user, message);
    }

    // check thu co join group caht chua neu r thi nhan message
    public async Task JoinGroup(string group, string user)
    {
        Console.WriteLine("join group");
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
        await Clients.Group(group).SendAsync("ReceiveMessageGroup", group, "System", $"{user} joined group: {group}");
    }
    //out group
    public async Task LeaveGroup(string group, string user)
    {
        Console.WriteLine("Leave group");
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        await Clients.Group(group).SendAsync("ReceiveMessageGroup", group, "System", $"{user} left group: {group}");
    }
}