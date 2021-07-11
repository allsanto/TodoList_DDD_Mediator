using MediatR;

namespace Domain.Commands.DeleteList
{
    public class DeleteListCommand : IRequest<int>
    {
        protected DeleteListCommand()
        {

        }
        public int idlist { get; set; }
    }
}
