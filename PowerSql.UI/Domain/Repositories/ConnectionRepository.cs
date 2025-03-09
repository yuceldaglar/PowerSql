using PowerSql.UI.Database;
using PowerSql.UI.Domain.Models;

namespace PowerSql.UI.Domain.Repositories
{
    public class ConnectionRepository
    {
        private readonly IDatabase _database;

        public ConnectionRepository(IDatabase database)
        {
            _database = database;
        }

        public void Add(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);

            var data = _database.Read();
            data.Connections.Add(connection);

            _database.Save(data);
        }

        public Connection Get(Guid id)
        {
            return _database
                .Read()
                .Connections.FirstOrDefault(c => c.Id == id);
        }

        public List<Connection> GetAll()
        {
            return _database
                .Read()
                .Connections;
        }

        public void Delete(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);

            var data = _database.Read();
            data.Connections.RemoveAll(c => c.Id == connection.Id);

            _database.Save(data);
        }

        public void Update(Connection connection)
        {
            ArgumentNullException.ThrowIfNull(connection);

            var data = _database.Read();
            for (int i = 0; i < data.Connections.Count; i++)
            {
                if (data.Connections[i].Id == connection.Id)
                {
                    data.Connections[i] = connection;
                    break;
                }
            }

            _database.Save(data);
        }
    }
}
