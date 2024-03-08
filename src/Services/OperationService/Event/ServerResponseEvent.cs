namespace OperationService.Event
{
    public class ServerResponseEvent : BaseSocketEvent
    {
        public ServerResponseEvent(string messageContent) =>
            MessageContent = messageContent;
    }
}
