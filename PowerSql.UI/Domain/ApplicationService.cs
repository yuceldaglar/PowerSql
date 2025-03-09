using Microsoft.Data.SqlClient;
using PowerSql.UI.Domain.Models;
using PowerSql.UI.Domain.Repositories;
using System.Data;

namespace PowerSql.UI.Domain
{
    public class ApplicationService
    {
        public event EventHandler ConnectionsUpdated;
        public event EventHandler<Query> QueryUpdated;

        private readonly ConnectionRepository _connectionRepository;
        private readonly QueryRepository _queryRepository;

        public ApplicationService(ConnectionRepository connectionRepository, QueryRepository queryRepository)
        {
            ArgumentNullException.ThrowIfNull(connectionRepository);
            ArgumentNullException.ThrowIfNull(queryRepository);

            _connectionRepository = connectionRepository;
            _queryRepository = queryRepository;
        }

        public void AddConnection(Connection connection)
        {
            _connectionRepository.Add(connection);

            ConnectionsUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void AddQuery(Query query)
        {
            _queryRepository.Add(query);
        }

        public void DeleteConnection(Connection connection)
        {
            _connectionRepository.Delete(connection);

            ConnectionsUpdated?.Invoke(this, EventArgs.Empty);
        }

        public (DataSet, List<string>) ExecuteQuery(string sql, Guid connectionId)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(sql);
            Equals(connectionId, Guid.Empty);

            var connection = _connectionRepository.Get(connectionId);
            var messages = new List<string>();

            using var sqlConnection = new SqlConnection(connection.GetConnectionString());
            using var sqlCommand = new SqlCommand(sql, sqlConnection);
            using var adapter = new SqlDataAdapter(sqlCommand);

            sqlConnection.InfoMessage += infoMessageHandler;
            sqlConnection.FireInfoMessageEventOnUserErrors = true;
            sqlConnection.Open();

            var dataTable = new DataTable();
            var dataSet = new DataSet();
            var rows = adapter.Fill(dataSet);
            sqlConnection.InfoMessage -= infoMessageHandler;

            return (dataSet, messages);

            void infoMessageHandler(object sender, SqlInfoMessageEventArgs e)
            {
                messages.Add(e.Message);
            }
        }

        private void SqlConnection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">>> " + e.Message);
        }

        public Connection GetConnection(Guid connectionId)
        {
            return _connectionRepository.Get(connectionId);
        }

        public Connection[] GetConnections()
        {
            return [.. _connectionRepository.GetAll()];
        }

        public List<Query> GetQueries()
        {
            return _queryRepository.GetAll();
        }

        public Query GetQuery(Guid queryId)
        {
            return _queryRepository.Get(queryId);
        }

        public void UpdateConnection(Connection connection)
        {
            _connectionRepository.Update(connection);

            ConnectionsUpdated?.Invoke(this, EventArgs.Empty);
        }

        public void UpdateQuery(Query query)
        {
            _queryRepository.Update(query);

            QueryUpdated?.Invoke(this, query);
        }
    }
}
