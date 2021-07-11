using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace Infra.Base
{
    public class RepositoryBase
    {
        protected IConfiguration configuration;

        internal IDbConnection Connection
        {
            get
            {
                var connect = new NpgsqlConnection(configuration["ConnectionString"]);

                connect.Open();
                return connect;
            }
        }

    }
}
