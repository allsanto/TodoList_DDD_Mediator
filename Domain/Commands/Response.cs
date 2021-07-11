namespace Domain.Commands
{
    public class Response
    {
        public string Message { get; set; }

        public Response(string message)
        {
            Message = message;
        }
    }
}
