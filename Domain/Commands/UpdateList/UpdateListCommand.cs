using MediatR;

namespace Domain.Commands.UpdateList
{
    public class UpdateListCommand : IRequest<Response>
    {
        protected UpdateListCommand()
        {

        }
        public int idlist { get; set; }
        public string text { get; set; }
        public bool done { get; set; }
    }
}
