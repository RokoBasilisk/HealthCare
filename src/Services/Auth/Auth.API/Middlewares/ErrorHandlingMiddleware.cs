using Auth.API.Models.Responses;
using Core.Extensions;
using System.Net.Mime;

namespace Auth.API.Middlewares
{
    public class ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
    {
        private const string ErrorMessage = "An internal error occurred while processing your request.";
        private static readonly string ApiResponseJson = ApiResponse.IntervalServerError(ErrorMessage).ToJson();

        private readonly RequestDelegate _next = next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unexpected exception was thrown: {Message}", ex.Message);

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = MediaTypeNames.Application.Json;
                await context.Response.WriteAsync(ApiResponseJson);
            }
        }
    }

    public static class ErrorHandlingMiddlewareExtensions
    {
        public static void UseErrorHandling(this IApplicationBuilder builder) =>
            builder.UseMiddleware<ErrorHandlingMiddleware>();
    }
}
