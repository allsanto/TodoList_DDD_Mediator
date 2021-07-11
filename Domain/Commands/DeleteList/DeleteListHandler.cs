using Domain.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commands.DeleteList
{
    public class DeleteListHandler : IRequestHandler<DeleteListCommand, int>
    {
        private readonly IRepositoryList _repository;
        public DeleteListHandler(IRepositoryList repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(DeleteListCommand cmd, CancellationToken cancellationToken)
        {
            var list = new List { idlist = cmd.idlist };

            var entity = await _repository.Delete(list.idlist);

            return entity;
        }
    }
}
