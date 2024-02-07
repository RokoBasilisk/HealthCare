using Ardalis.Result;
using Auth.Application.Wrappers.Abstracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse>(ILogger<ValidationBehavior<TRequest, TResponse>> logger) : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            var validationErrors = getValidationErrors(response);


            if (validationErrors.Count > 0)
            {
                var groupedErrors = validationErrors.GroupBy(error => error.Identifier);

                var errorsString = string.Join("\n", groupedErrors.Select(group =>
                    $"\tIdentifier: {group.Key}\n" +
                    string.Join("\n", group.Select(error => $"\t - '{error.ErrorCode}': {error.ErrorMessage}"))));
                _logger.LogWarning("Validation Errors: {{\n{errors}\n\t}}", errorsString);
            }

            return response;
        }

        private List<ValidationError> getValidationErrors(TResponse response)
        {
            List<ValidationError> errors = [];

            if (response == null) 
                return errors;
            // Get the actual Type object for TResponse
            Type responseType = typeof(TResponse);

            // Access the nested type within Result<T>
            Type nestedType = responseType.GetGenericArguments()[0];

            // Cast the response to the actual Result<nestedType> type
            var resultResponse = (Result<object>)response; // Cast to base Result<object> first
            var nestedResult = resultResponse.Value;      // Access the nested Result

            if (nestedResult.GetType() == typeof(Result<>).MakeGenericType(nestedType))
            {
                errors.AddRange(nestedResult.GetType().GetProperty("ValidationErrors").GetValue(nestedResult) as List<ValidationError> ?? []);
            }

            return errors;
        }
    }
}
