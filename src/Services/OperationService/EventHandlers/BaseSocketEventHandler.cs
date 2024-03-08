using Fleck;
using OperationService.Event;
using System.Text.Json;

namespace OperationService.EventHandlers
{
    public abstract class BaseSocketEventHandler<T> where T : BaseSocketEvent
    {
        public async Task InvokeEventHandle (string rawMessage, IWebSocketConnection socket)
        {
            T socketEvent = JsonSerializer.Deserialize<T>(rawMessage)
                ?? throw new ArgumentException(
                    "Could not deserialize into " + typeof(T).Name + " from Message Content: " + rawMessage);

            await Handle(socketEvent, socket);
        }
        public abstract Task Handle (T socketEvent, IWebSocketConnection socket);
    }
}
