using System.Net;

namespace theatrebel.Exceptions
{
    public class HttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }

        public HttpException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
