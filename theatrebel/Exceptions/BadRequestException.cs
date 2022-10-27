namespace theatrebel.Exceptions
{
    public class BadRequestException : HttpException
    {
        public BadRequestException(string message) : base(message, System.Net.HttpStatusCode.BadRequest) { }
    }
}
