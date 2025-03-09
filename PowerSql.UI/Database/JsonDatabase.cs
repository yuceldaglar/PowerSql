using Newtonsoft.Json;
using PowerSql.UI.Domain.Models;
using PowerSql.UI.Library;

namespace PowerSql.UI.Database
{
    public class JsonDatabase : IDatabase
    {
        private const string DataFilePath = "data.json";
        private readonly IFileSystem _fileSystem;

        public JsonDatabase(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public ApplicationData Read()
        {
            ApplicationData data = null;

            if (_fileSystem.FileExists(DataFilePath))
            {
                string json = _fileSystem.ReadAllText("data.json");
                data = JsonConvert.DeserializeObject<ApplicationData>(json);
            }

            return data ?? new ApplicationData();
        }

        public void Save(ApplicationData data)
        {
            string json = JsonConvert.SerializeObject(data);
            _fileSystem.WriteAllText(DataFilePath, json);
        }
    }
}
