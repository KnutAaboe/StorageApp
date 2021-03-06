using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SQLDataAccess(IConfiguration config)
        {
            _config = config;

        }

        //Takes inn a string sql, a generic type parameters and returns a list of T, a generic type
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //Here we are querying our sql database, returning a IEnumereble type T list
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        //Running operations which does not return anything, just changes, like saving
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //Running the operations
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
