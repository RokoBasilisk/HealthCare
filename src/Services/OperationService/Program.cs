
using Fleck;
using OperationService.Event;
using OperationService.EventHandlers;
using OperationService.Service;
using System.Reflection;
using System.Text.Json;
using FluentValidation;
using OperationService.Extensions;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);
Assembly ThisAssembly = Assembly.GetExecutingAssembly();

Dictionary<string, Type> eventHandlerDict = [];
foreach (Type type in ThisAssembly.GetTypes())
{
    if (type is not null
        && type.BaseType.IsGenericType
        && type.BaseType.GetGenericTypeDefinition() == typeof(BaseSocketEventHandler<>))
    {
        builder.Services.AddScoped(type);

        Type typeEvent = type.BaseType.GetGenericArguments()[0];

        eventHandlerDict[typeEvent.Name] = type;
    }
}

builder.Services
    .AddValidatorsFromAssembly(ThisAssembly);

builder.Services
    .ConfigureAppSettings()
    .AddCacheService(builder.Configuration);

var app = builder.Build();

var server = new WebSocketServer("ws://0.0.0.0:8181");

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

        if (baseSocketEvent.EventType is null || !eventHandlerDict.ContainsKey(baseSocketEvent.EventType))
        {
            var responseEvent = new ServerResponseEvent($"Invalid type of event {baseSocketEvent.EventType}");

            var responseJson = JsonSerializer.Serialize(responseEvent);

            await ws.Send(responseJson);
            return;
        }

        Type eventHandlerType = eventHandlerDict[baseSocketEvent.EventType];
        
        dynamic eventHandler = serviceScope.ServiceProvider.GetService(eventHandlerType);

        await eventHandler.InvokeEventHandle(message, ws);

        Console.WriteLine($"{eventHandlerType.Name} is completed");
    };
});

app.Run();