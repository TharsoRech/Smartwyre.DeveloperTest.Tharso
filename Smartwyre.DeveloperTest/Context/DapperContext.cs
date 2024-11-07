using Dapper;
using Microsoft.Data.SqlClient;
using Smartwyre.DeveloperTest.Configuration;
using Smartwyre.DeveloperTest.Context.Interface.NerdStore.Enterprise.Core.Infrastructure.Context.Interface;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Context
{
    public class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        public DapperContext()
        {
            _connectionString = AppSettings.Instance.SqlConnection;
        }

        public async Task<int> ExecuteAsync(string sql, object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync(sql, entity);
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QuerySingleOrDefaultAsync(sql, entity);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object entity = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<T>(sql, entity);
            }
        }

        public async Task<T> QueryFirstAsync<T>(string sql, object entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstAsync(sql, entity);
            }
        }
    }
}