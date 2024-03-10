using Core.SharedKernel;
using Fleck;
using FluentValidation;
using OperationService.Event;
using OperationService.Service;
using System.Text.Json;

namespace OperationService.EventHandlers
{
    public class JoinRoomEventHandler : BaseSocketEventHandler<JoinRoomEvent>
    {
        private readonly ICacheService _cacheService;
        public JoinRoomEventHandler(IValidator<JoinRoomEvent> _validator, ICacheService cacheService) : base(_validator)
        {
            _cacheService = cacheService;
        }

        public override async Task<Task> Handle(JoinRoomEvent socketEvent, IWebSocketConnection socket)                                       
        {
            StateService.JoinRoom(socket, socketEvent.RoomId);

            var id = await _cacheService.SetAsync(socket.ConnectionInfo.ClientIpAddress, socket.ConnectionInfo.Id.ToString());

            var responseEvent = new ServerResponseEvent($"Join room {socketEvent.RoomId} successfully");

            var responseJson = JsonSerializer.Serialize(responseEvent);

            socket.Send(responseJson);

            return Task.CompletedTask;
        }
    }
}
