namespace PowerSql.UI.Domain.Models
{
    public class ApplicationData
    {
        public List<Connection> Connections { get; set; }
        public List<Query> Queries { get; set; }

        public ApplicationData()
        {
            Connections = [];
            Queries = [];
        }
    }
}
