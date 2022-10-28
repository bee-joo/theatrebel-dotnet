namespace theatrebel.Data.Responses
{
    public class NotFoundResponse : ErrorResponse
    {
        public NotFoundResponse(string message) : base(message, System.Net.HttpStatusCode.NotFound) { }
    }
}
