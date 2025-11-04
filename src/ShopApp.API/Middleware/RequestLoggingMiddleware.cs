namespace ShopApp.API.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next; _logger = logger;
        }
        public async Task Invoke(HttpContext ctx)
        {
            _logger.LogInformation("Handling {method} {path}", ctx.Request.Method, ctx.Request.Path);
            await _next(ctx);
            _logger.LogInformation("Handled {statusCode}", ctx.Response.StatusCode);
        }
    }
}
