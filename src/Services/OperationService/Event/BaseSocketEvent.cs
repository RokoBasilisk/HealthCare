using lib;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OperationService.Event
{
    public class BaseSocketEvent
    {
        public string MessageContent {  get; set; }

        public string EventType { get; set; }
    }
}
