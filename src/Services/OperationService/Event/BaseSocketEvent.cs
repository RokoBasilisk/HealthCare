namespace OperationService.Event
{
    public class BaseSocketEvent
    {
        public string? MessageContent {  get; set; }

        public string EventType { get; set; } = "UnknownEvent";
    }
}
