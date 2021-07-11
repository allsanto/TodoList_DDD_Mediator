using MediatR;

namespace Domain.Commands.InsertList
{
    public class InsertListCommand : IRequest<Response>
    {
        protected InsertListCommand()
        {

        }
        public string text { get; set; }
        public bool done { get; set; }
    }
}
