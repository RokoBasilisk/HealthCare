using Core.Extensions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Auth.Application.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var commandName = request.GetGenericTypeName();

            _logger.LogInformation("----- Handling command '{commandName}'", commandName);

            var timer = new Stopwatch();
            timer.Start();

            var response = await next();

            timer.Stop();

            var timeTaken = timer.Elapsed.TotalSeconds;
            _logger.LogInformation("----- Command '{commandName}' handled ({TimeTaken} seconds)", commandName, timeTaken);

            return response;
        }
    }
}
