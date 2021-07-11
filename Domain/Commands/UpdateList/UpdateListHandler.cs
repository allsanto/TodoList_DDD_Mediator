using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.UpdateList
{
    public class UpdateListHandler : IRequestHandler<UpdateListCommand, Response>
    {
        private readonly IRepositoryList _repository;
        public UpdateListHandler(IRepositoryList repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(UpdateListCommand cmd, CancellationToken cancellationToken)
        {
            Entities.List item = await _repository.GetById(cmd.idlist);

            item.AlterItem(cmd.text, cmd.done);

            if (item == null)
            {
                return new Response("Item não encontrado");
            }

            await _repository.Update(item);

            return new Response("Item alterado");
        }
    }
}
