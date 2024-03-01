using OperationService.Hubs;
using OperationService.Models;
using System.Net;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();
builder.WebHost.UseUrls("http://localhost:6969");
var app = builder.Build();
app.MapHub<GameHub>("/room");

//app.UseWebSockets();

//var connections = new List<WebSocket>();

//var connectionDict = new Dictionary<string, SocketData>();

//app.Map("/ws", async context =>
//{
//    if (context.WebSockets.IsWebSocketRequest)
//    {
//        var userId = context.Request.Query["userId"];
//        var roomId = context.Request.Query["roomId"];

//        using var ws = await context.WebSockets.AcceptWebSocketAsync();
//        SocketData socketData = new SocketData(socket: ws, roomId: roomId);
//        connectionDict.Add(userId, socketData);
//        //connections.Add(ws);

//        await BroadCast($"user {userId} joined the room");
//        await BroadCast($"{connections.Count} users connected");
//        await ReceiveMessage(ws, 
//            async (result, buffer) =>
//            {
//                if (result.MessageType == WebSocketMessageType.Text)
//                {
//                    string message = Encoding.UTF8.GetString(buffer, 0, result.Count);
//                    await BroadCast($"{userId}: {message}");
//                }
//                else if (result.MessageType == WebSocketMessageType.Close  || ws.State == WebSocketState.Aborted)
//                {
//                    connections.Remove(ws);
//                    await BroadCast($"user {userId} left the room");
//                    await BroadCast($"{connections.Count} users connected");
//                    await ws.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
//                }
//            });
//    }
//    else
//    {
//        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
//    }
//});

//async Task BroadCast(string message)
//{
//    var bytes = Encoding.UTF8.GetBytes(message);
//    foreach (var socket in connections)
//    {
//        if (socket.State == WebSocketState.Open)
//        {
//            var arraySegment = new ArraySegment<byte>(bytes, 0, bytes.Length);
//            await socket.SendAsync(
//                arraySegment,
//                WebSocketMessageType.Text,
//                true,
//                CancellationToken.None);
//        }
//    }
//}

//async Task ReceiveMessage(WebSocket webSocket, Action<WebSocketReceiveResult, byte[]> handleMessage)
//{
//    var buffer = new byte[1024 * 4];

//    while (webSocket.State == WebSocketState.Open)
//    {
//        var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
//        handleMessage(result, buffer);
//    }
//}

await app.RunAsync();
