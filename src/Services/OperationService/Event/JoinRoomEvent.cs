using lib;

namespace OperationService.Event
{
    public class JoinRoomEvent : BaseSocketEvent
    {
        public string RoomId { get; set; }
    }
}
