using System.ComponentModel.DataAnnotations;

namespace WebApplication52.Presentation.Middleware
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate next;
        private readonly ILogger<GlobalExceptionHandler> logger;
        public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex switch
                {

                    NotImplementedException => StatusCodes.Status501NotImplemented,
                    ValidationException => StatusCodes.Status400BadRequest,
                    ArgumentException => StatusCodes.Status400BadRequest,
                    KeyNotFoundException => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                };

                var message = new
                {
                    message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(message);
            }
        }
    }
}
