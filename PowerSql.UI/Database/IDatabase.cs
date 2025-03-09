using PowerSql.UI.Domain.Models;

namespace PowerSql.UI.Database
{
    public interface IDatabase
    {
        ApplicationData Read();
        void Save(ApplicationData data);
    }
}