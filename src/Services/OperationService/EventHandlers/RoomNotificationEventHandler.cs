using Fleck;
using OperationService.Event;
using OperationService.Service;
using System.Text.Json;

namespace OperationService.EventHandlers
{
    public class RoomNotificationEventHandler : BaseSocketEventHandler<RoomNotificationEvent>
    {
        public override Task Handle(RoomNotificationEvent socketEvent, IWebSocketConnection socket)
        {
            if (socketEvent.RoomId is null)
            {
                var responseErrorEvent = new ServerResponseEvent($"Notification room action required RoomId");

                var responseErrorJson = JsonSerializer.Serialize(responseErrorEvent);

                socket.Send(responseErrorJson);
                return Task.CompletedTask;
            }

            StateService.RoomNotification(socket, socketEvent.MessageContent, socketEvent.RoomId);

            return Task.CompletedTask;
        }
    }
}
