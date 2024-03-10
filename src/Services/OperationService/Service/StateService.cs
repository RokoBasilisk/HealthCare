using Fleck;
using System;

namespace OperationService.Service
{
    public class WsWithMetadata(IWebSocketConnection connection, string userId)
    {
        public IWebSocketConnection Connection { get; set; } = connection;
        public string UserId { get; set; } = userId;
    }

    public static class StateService
    {
        public static Dictionary<Guid, WsWithMetadata> Connections = [];
        public static Dictionary<string, HashSet<Guid>> Rooms = [];

        public static bool AddConnection(IWebSocketConnection ws, string userId)
        {
            return Connections.TryAdd(ws.ConnectionInfo.Id,
                new WsWithMetadata(ws, userId));
        }

        public static bool JoinRoom(IWebSocketConnection ws, string roomId)
        {
            Guid socketId = ws.ConnectionInfo.Id;
            if (!Rooms.ContainsKey(roomId))
            {
                Console.WriteLine($"Creating room {roomId}");
                Rooms.Add(roomId, new HashSet<Guid>());
            }
            return Rooms[roomId].Add(socketId);
        }

        public static void RoomNotification(IWebSocketConnection ws, string message, string roomId)
        {
            if (Rooms.TryGetValue(roomId, out var room))
            {
                foreach (var user in room)
                {
                    if (Connections.TryGetValue(user, out var userSocket))
                    {
                        if (ws != userSocket.Connection)
                        {
                            userSocket.Connection.Send(message);
                        }
                    }
                }
            }
        }
    }
}
