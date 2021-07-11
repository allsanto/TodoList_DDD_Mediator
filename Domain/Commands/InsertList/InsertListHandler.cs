using Domain.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands.UpdateList;

namespace Domain.Commands.InsertList
{
    public class UpdateListHandler : IRequestHandler<InsertListCommand, Response>
    {
        private readonly IRepositoryList _repository;
        public UpdateListHandler(IRepositoryList repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(InsertListCommand cmd, CancellationToken cancellationToken)
        {
            var itemText = await _repository.GetByText(cmd.text);

            if (itemText != null)
            {
                return new Response("Item já inserido!");
            }
            else
            {
                var list = new List { text = cmd.text, done = cmd.done };

                await _repository.Insert(list);

                return new Response("Item cadastrado com sucesso!");
            }   
        }
    }
}
