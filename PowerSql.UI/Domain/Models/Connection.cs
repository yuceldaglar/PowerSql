using Microsoft.Data.SqlClient;

namespace PowerSql.UI.Domain.Models
{
    public class Connection
    {
        public Guid Id { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }

        public Connection()
        {
            Id = Guid.NewGuid();
        }

        public string GetConnectionString(string database)
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = Server,
                InitialCatalog = database,
                IntegratedSecurity = IntegratedSecurity,
                UserID = Username,
                Password = Password,
                TrustServerCertificate = true
            };

            return builder.ConnectionString;
        }

        public override string ToString()
        {
            return Server ?? "?";
        }
    }
}
