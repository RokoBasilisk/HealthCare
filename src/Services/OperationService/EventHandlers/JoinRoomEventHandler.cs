using Fleck;
using OperationService.Event;
using OperationService.Service;
using System.Text.Json;

namespace OperationService.EventHandlers
{
    public class JoinRoomEventHandler : BaseSocketEventHandler<JoinRoomEvent>
    {
        public override Task Handle(JoinRoomEvent socketEvent, IWebSocketConnection socket)                                       
        {
            if (socketEvent.RoomId is null)
            {
                var responseErrorEvent = new ServerResponseEvent($"Join room action required RoomId");

                var responseErrorJson = JsonSerializer.Serialize(responseErrorEvent);

                socket.Send(responseErrorJson);
                return Task.CompletedTask;
            }

            StateService.JoinRoom(socket, socketEvent.RoomId);

            var responseEvent = new ServerResponseEvent($"Join room {socketEvent.RoomId} successfully");

            var responseJson = JsonSerializer.Serialize(responseEvent);

            socket.Send(responseJson);

            return Task.CompletedTask;
        }
    }
}
