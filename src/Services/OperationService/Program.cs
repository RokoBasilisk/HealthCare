
using Fleck;
using lib;
using OperationService.Event;
using OperationService.EventHandlers;
using OperationService.Extensions;
using OperationService.Service;
using System.Reflection;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

var clientEventsHandlers = builder.FindAndInjectClientEventHandlers(Assembly.GetExecutingAssembly());

IDictionary<string, Type> eventHandlerMap = new Dictionary<string, Type>();
foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
{
    if (type is not null
        && type.BaseType.IsGenericType
        && type.BaseType.GetGenericTypeDefinition() == typeof(BaseSocketEventHandler<>))
    {
        builder.Services.AddSingleton(type);

        Type typeEvent = type.BaseType.GetGenericArguments()[0];

        eventHandlerMap[typeEvent.Name] = type;
    }
}

var app = builder.Build();

var server = new WebSocketServer("ws://0.0.0.0:8181");

var userConnectionList = new List<IWebSocketConnection>();

await using var serviceScope = app.Services.CreateAsyncScope();


server.Start(ws =>
{
    ws.OnOpen = () =>
    {

        ws.ConnectionInfo.Headers.TryGetValue("Id", out string? userId);

        if (userId is null)
            ws.Close();


        StateService.AddConnection(ws, userId);
        Console.WriteLine("New User connected");
        Console.WriteLine("Current List Users: " + StateService.Connections.Count);
    };

    ws.OnClose = () =>
    {
        StateService.Connections.Remove(ws.ConnectionInfo.Id);
        Console.WriteLine("User disconnected");
        Console.WriteLine("Current List Users: " + StateService.Connections.Count);
    };

    ws.OnMessage = async (message) =>
    {
        BaseSocketEvent baseSocketEvent = 
            JsonSerializer.Deserialize<BaseSocketEvent>(message) ?? throw new ArgumentException(
                "Could not deserialize into " + typeof(BaseSocketEvent).Name + " from Message Content: " + message);
        Type eventType = Type.GetType(baseSocketEvent.EventType);

        if (!eventHandlerMap.ContainsKey(baseSocketEvent.EventType))
        {
            var responseEvent = new ServerResponseEvent($"Invalid type of event {baseSocketEvent.EventType}");

            var responseJson = JsonSerializer.Serialize(responseEvent);

            ws.Send(responseJson);
            return;
        }

        Type eventHandlerType = eventHandlerMap[baseSocketEvent.EventType];
        
        dynamic eventHandler = serviceScope.ServiceProvider.GetService(eventHandlerType);

        await eventHandler.InvokeEventHandle(message, ws);

        Console.WriteLine($"{eventHandlerType.Name} is completed");
    };
});

app.Run();