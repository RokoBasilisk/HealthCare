namespace OperationService.Event
{
    public class RoomNotificationEvent : BaseSocketEvent
    {
        public string RoomId {  get; set; }
    }
}
