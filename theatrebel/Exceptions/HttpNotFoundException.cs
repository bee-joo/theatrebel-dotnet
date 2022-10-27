namespace theatrebel.Exceptions
{
    public class HttpNotFoundException : HttpException
    {
        public HttpNotFoundException(string message) : base(message, System.Net.HttpStatusCode.NotFound) { }
    }
}
