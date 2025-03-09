namespace PowerSql.UI.Domain.Models
{
    public class Query
    {
        public bool Archived { get; set; }
        public Guid ConnectionId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sql { get; set; }

        public Query()
        {
            Id = Guid.NewGuid();
        }

        override public string ToString()
        {
            return Name;
        }
    }
}
