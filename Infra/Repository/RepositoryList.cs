using Dapper;
using Domain.Commands;
using Domain.Entities;
using Domain.Interfaces;
using Infra.Base;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryList : RepositoryBase, IRepositoryList
    {
        public RepositoryList(IConfiguration configuration)
        {
            base.configuration = configuration;
        }

        public async Task<IEnumerable<List>> GetAll()
        {
            using var db = Connection;

            var query = @"select * from todolist";

            return await db.QueryAsync<List>(query);
        }

        public async Task<Response> Insert(List list)
        {
            using var db = Connection;

            var query = @"insert into todolist(text, done) values (@text, @done)";

            return await db.ExecuteScalarAsync<Response>(query, new
            {
                list.text,
                list.done
            });
        }

        public async Task<int> Delete(int id)
        {
            using var db = Connection;

            var query = @"delete from todolist
                            where idlist = @id";

            return await db.ExecuteAsync(query, new { id });
        }

        public async Task<List> Update(List list)
        {
            using var db = Connection;

            var query = @"update todolist 
                            set text = @text,
                                done = @done
                            where idlist = @idlist";

            return await db.ExecuteScalarAsync<List>(query, new
            {
                list.idlist,
                list.text,
                list.done
            });
        }

        public async Task<List> GetById(int id)
        {
            using var db = Connection;

            var query = @"SELECT idlist,
                                 text,
                                 done
                          FROM todolist
                            WHERE idlist = @id";

            return await db.QueryFirstOrDefaultAsync<List>(query, new { id });
        }

        public async Task<List> GetByText(string text)
        {
            using var db = Connection;

            var query = @"SELECT * FROM todolist
                            WHERE text = @text";

            return await db.QueryFirstOrDefaultAsync<List>(query, new { text });
        }
    }
}
