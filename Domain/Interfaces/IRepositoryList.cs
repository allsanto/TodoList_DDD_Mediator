using Domain.Commands;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRepositoryList
    {
        Task<Response> Insert(List list);
        Task<IEnumerable<List>> GetAll();
        Task<int> Delete(int id);
        Task<List> Update(List list);
        Task<List> GetById(int id);
        Task<List> GetByText(string text);
    }
}
