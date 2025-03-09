using PowerSql.UI.Database;
using PowerSql.UI.Domain.Models;

namespace PowerSql.UI.Domain.Repositories
{
    public class QueryRepository
    {
        private readonly IDatabase _database;

        public QueryRepository(IDatabase database)
        {
            _database = database;
        }

        public void Add(Query query)
        {
            ArgumentNullException.ThrowIfNull(query);

            var data = _database.Read();
            data.Queries.Add(query);
            _database.Save(data);
        }

        public Query Get(Guid id)
        {
            return _database
                .Read()
                .Queries.FirstOrDefault(q => q.Id == id);
        }

        public List<Query> GetAll()
        {
            return _database.Read().Queries;
        }

        public void Update(Query query)
        {
            ArgumentNullException.ThrowIfNull(query);

            var data = _database.Read();
            for (int i = 0; i < data.Queries.Count; i++)
            {
                if (data.Queries[i].Id == query.Id)
                {
                    data.Queries[i] = query;
                    break;
                }
            }

            _database.Save(data);
        }
    }
}
