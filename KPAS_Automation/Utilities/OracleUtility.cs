using Dapper;
using KPAS_Automation.Infrastructure.Config;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace KPAS_Automation.Utilities
{
    public class OracleUtility : IDisposable
    {
        private readonly string _connectionString;
        private IDbConnection _connection;

        public OracleUtility()
        {
            _connectionString = TestConfigReader.OracleDBConnectionString;
        }

        public IDbConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State == ConnectionState.Closed)
                {
                    _connection = new OracleConnection(_connectionString);
                    _connection.Open();
                }
                return _connection;
            }
        }

        public T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            return Connection.QueryFirstOrDefault<T>(sql, parameters);
        }

        public void Dispose()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }
    }
}
