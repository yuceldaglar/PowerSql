using Moq;
using Newtonsoft.Json;
using PowerSql.UI.Database;
using PowerSql.UI.Domain.Models;
using PowerSql.UI.Library;

namespace PowerSql.Test
{
    [TestFixture]
    public class JsonDatabaseTests
    {
        private Mock<IFileSystem> _mockFileSystem;
        private JsonDatabase _database;
        private const string DataFilePath = "data.json";

        [SetUp]
        public void Setup()
        {
            _mockFileSystem = new Mock<IFileSystem>();
            _database = new JsonDatabase(_mockFileSystem.Object);
        }

        [Test]
        public void Read_ShouldReturnData_WhenFileExists()
        {
            var expectedData = new ApplicationData { Connections = [new Connection { Id = Guid.NewGuid(), Database = "TestDB" }] };
            var json = JsonConvert.SerializeObject(expectedData);
            _mockFileSystem.Setup(fs => fs.FileExists(DataFilePath)).Returns(true);
            _mockFileSystem.Setup(fs => fs.ReadAllText(DataFilePath)).Returns(json);

            var result = _database.Read();

            Assert.That(result.Connections, Has.Count.EqualTo(expectedData.Connections.Count));
            Assert.That(result.Connections[0].Id, Is.EqualTo(expectedData.Connections[0].Id));
        }

        [Test]
        public void Read_ShouldReturnNewData_WhenFileDoesNotExist()
        {
            _mockFileSystem.Setup(fs => fs.FileExists(DataFilePath)).Returns(false);

            var result = _database.Read();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Connections, Is.Empty);
        }

        [Test]
        public void Save_ShouldWriteDataToFile()
        {
            var data = new ApplicationData { Connections = [new Connection { Id = Guid.NewGuid(), Database = "TestDB" }] };
            var json = JsonConvert.SerializeObject(data);

            _database.Save(data);

            _mockFileSystem.Verify(fs => fs.WriteAllText(DataFilePath, json), Times.Once);
        }
    }
}
