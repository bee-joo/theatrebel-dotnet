namespace theatrebel.Data.Responses
{
    public class BadRequestResponse : ErrorResponse
    {
        public BadRequestResponse(string message) : base(message, System.Net.HttpStatusCode.BadRequest) { }
    }
}
