using System.Net;
using theatrebel.Data.Responses;

namespace theatrebel.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                if (exception is HttpException e)
                {
                    response.StatusCode = (int)e.StatusCode;
                    await response.WriteAsJsonAsync(new ErrorResponse(e));
                }
                else
                {
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    _logger.LogError(exception, exception.Message);
                    await response.WriteAsJsonAsync(new ErrorResponse("Server error", response.StatusCode));
                }

            }
        }
    }
}
