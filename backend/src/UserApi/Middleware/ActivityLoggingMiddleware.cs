using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace UserApi.Middleware
{
    public class ActivityLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ActivityLoggingMiddleware> _logger;

        public ActivityLoggingMiddleware(RequestDelegate next, ILogger<ActivityLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            // Log the request details
            _logger.LogInformation("Received request: {Method} {Path}", context.Request.Method, context.Request.Path);

            // Call the next middleware in the pipeline
            await _next(context);

            // Log the response details
            _logger.LogInformation("Sending response: {StatusCode}", context.Response.StatusCode);
        }
    }
}
