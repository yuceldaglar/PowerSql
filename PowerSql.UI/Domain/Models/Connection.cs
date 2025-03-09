using Microsoft.Data.SqlClient;

namespace PowerSql.UI.Domain.Models
{
    public class Connection
    {
        public string Database { get; set; }
        public Guid Id { get; set; }
        public bool IntegratedSecurity { get; set; }
        public string Password { get; set; }
        public string Server { get; set; }
        public string Username { get; set; }

        public Connection()
        {
            Id = Guid.NewGuid();
        }

        public string GetConnectionString()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = Server,
                InitialCatalog = Database,
                IntegratedSecurity = IntegratedSecurity,
                UserID = Username,
                Password = Password,
                TrustServerCertificate = true
            };

            return builder.ConnectionString;
        }

        public override string ToString()
        {
            return Server + " - " + Database;
        }
    }
}
