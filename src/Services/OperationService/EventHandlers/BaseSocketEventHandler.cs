using Fleck;
using FluentValidation;
using OperationService.Event;
using System.Text.Json;
using System.Threading;

namespace OperationService.EventHandlers
{
    public abstract class BaseSocketEventHandler<T>(IValidator<T> _validator) where T : BaseSocketEvent
    {
        public async Task InvokeEventHandle (string rawMessage, IWebSocketConnection socket)
        {

            T socketEvent = JsonSerializer.Deserialize<T>(rawMessage)
                ?? throw new ArgumentException(
                    "Could not deserialize into " + typeof(T).Name + " from Message Content: " + rawMessage); 
            
            var validationResult = await _validator.ValidateAsync(socketEvent);
            if (!validationResult.IsValid)
            {
                List<string> errorMessages = [];
                foreach (var validationError in validationResult.Errors)
                {
                    string errorMessage = $"{validationError.PropertyName}: {validationError.ErrorMessage}";
                    errorMessages.Add(errorMessage);
                }
                var responseErrorEvent = new ServerResponseEvent(errorMessages);

                var responseErrorJson = JsonSerializer.Serialize(responseErrorEvent);

                socket.Send(responseErrorJson);
                return;
            }

            await Handle(socketEvent, socket);
        }
        public abstract Task Handle (T socketEvent, IWebSocketConnection socket);
    }
}
