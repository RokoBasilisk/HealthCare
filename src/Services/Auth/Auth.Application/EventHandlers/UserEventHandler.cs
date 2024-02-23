using Auth.Application.Behaviors;
using Auth.Application.Wrappers.Abstracts;
using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.Entities.ClientAggregate.Events;
using Auth.Domain.Entities.EntityAggregate;
using Auth.Domain.Entities.RoleAggregate;
using Core.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.EventHandlers
{
    public class UserEventHandler(ILogger<UserEventHandler> logger) :
        INotificationHandler<UserRegistedEvent>
    {
        private readonly ILogger<UserEventHandler> _logger = logger;

        public async Task Handle(UserRegistedEvent notification, CancellationToken cancellationToken)
        {
            LogEvent(notification);
        }

        private void LogEvent<TEvent>(TEvent @event) where TEvent : ClientIdBaseEvent =>
        _logger.LogInformation("----- Triggering the event {EventName}, model: {EventModel}", typeof(TEvent).Name, @event.ToJson());
    }
}
