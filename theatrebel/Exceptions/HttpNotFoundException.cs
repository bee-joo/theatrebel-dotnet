namespace theatrebel.Exceptions
{
    public class NotFoundException : HttpException
    {
        public NotFoundException(string message) : base(message, System.Net.HttpStatusCode.NotFound) { }
    }
}
