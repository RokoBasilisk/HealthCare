namespace OperationService.Event
{
    public class ServerResponseEvent : BaseSocketEvent
    {
        public IEnumerable<string> ErrorMessages { get; set; }

        public ServerResponseEvent(string messageContent) =>
            MessageContent = messageContent;

        public ServerResponseEvent(IEnumerable<string> errorMessages) =>
            ErrorMessages = errorMessages;
    }
}
