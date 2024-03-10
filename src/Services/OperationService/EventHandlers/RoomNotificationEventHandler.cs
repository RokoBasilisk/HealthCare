using Fleck;
using FluentValidation;
using OperationService.Event;
using OperationService.Service;
using System.Text.Json;

namespace OperationService.EventHandlers
{
    public class RoomNotificationEventHandler : BaseSocketEventHandler<RoomNotificationEvent>
    {
        public RoomNotificationEventHandler(IValidator<RoomNotificationEvent> _validator) : base(_validator)
        {
        }

        public override Task Handle(RoomNotificationEvent socketEvent, IWebSocketConnection socket)
        {

            StateService.RoomNotification(socket, socketEvent.MessageContent, socketEvent.RoomId);

            return Task.CompletedTask;
        }
    }
}
