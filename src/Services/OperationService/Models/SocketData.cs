using System.Net.WebSockets;

namespace OperationService.Models
{
    public record SocketData
    {
        public SocketData(WebSocket socket, string roomId)
        {
            Socket = socket;
            RoomId = roomId;
        }

        public WebSocket Socket { get; }

        public string RoomId { get; }

        public IDictionary<string, IDictionary<string, string>> GroupSubscribes { get; } = new Dictionary<string, IDictionary<string, string>>();

        public int RoomCorrectAnswerCount { get; private set; } = 0;

        public List<string> GroupCorrectAnswer { get; } = new List<string>();

        public List<string> UserCorrectAnswer { get; } = new List<string>();

        public void UserCorrect(string answer)
        {
            UserCorrectAnswer.Add(answer);
            GroupCorrectAnswer.Add(answer);
            RoomCorrectAnswerCount++;
        }

        public void GroupCorrect(string answer)
        {
            GroupCorrectAnswer.Add(answer);
            RoomCorrectAnswerCount++;
        }

        public void RoomCorrect()
            => RoomCorrectAnswerCount++;
    }
}