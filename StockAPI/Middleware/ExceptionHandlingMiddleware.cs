namespace StockAPI.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = exception switch
            {
                KeyNotFoundException _ => StatusCodes.Status404NotFound,
                InvalidOperationException _ => StatusCodes.Status400BadRequest,
                ArgumentException _ => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

            var result = new
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message 
            };

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
