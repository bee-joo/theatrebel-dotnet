using System.Net;
using theatrebel.Exceptions;

namespace theatrebel.Data.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        
        public ErrorResponse(HttpException e)
        {
            Message = e.Message;
            StatusCode = (int)e.StatusCode;
        }

        public ErrorResponse(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public ErrorResponse(string message, HttpStatusCode statusCode)
        {
            Message = message;
            StatusCode = (int)statusCode;
        }
    }
}
