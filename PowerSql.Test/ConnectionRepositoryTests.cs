using Moq;
using PowerSql.UI.Database;
using PowerSql.UI.Domain.Models;
using PowerSql.UI.Domain.Repositories;

namespace PowerSql.Test
{
    [TestFixture]
    public class ConnectionRepositoryTests
    {
        private Mock<IDatabase> _mockDatabase;
        private ConnectionRepository _repository;
        private ApplicationData _data;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new Mock<IDatabase>();
            _repository = new ConnectionRepository(_mockDatabase.Object);
            _data = new ApplicationData { Connections = [] };
            _mockDatabase.Setup(db => db.Read()).Returns(_data);
        }

        [Test]
        public void Add_ShouldAddConnection()
        {
            var connection = new Connection { Id = Guid.NewGuid(), Server = "Test" };

            _repository.Add(connection);

            Assert.That(_data.Connections, Does.Contain(connection));
            _mockDatabase.Verify(db => db.Save(_data), Times.Once);
        }

        [Test]
        public void Get_ShouldReturnConnectionById()
        {
            var connection = new Connection { Id = Guid.NewGuid(), Server = "Test" };
            _data.Connections.Add(connection);

            var result = _repository.Get(connection.Id);

            AssertConnections(connection, result);
        }

        [Test]
        public void GetAll_ShouldReturnAllConnections()
        {
            var connection1 = new Connection { Id = Guid.NewGuid(), IntegratedSecurity = true, Password = "p1", Server = "s1", Username = "u1" };
            var connection2 = new Connection { Id = Guid.NewGuid(), IntegratedSecurity = false, Password = "p2", Server = "s2", Username = "u2" };
            _data.Connections.AddRange([connection1, connection2]);

            var result = _repository.GetAll();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result, Does.Contain(connection1));
            Assert.That(result, Does.Contain(connection2));
        }

        [Test]
        public void Delete_ShouldRemoveConnection()
        {
            var connection = new Connection { Id = Guid.NewGuid(), Server = "Test" };
            _data.Connections.Add(connection);

            _repository.Delete(connection);

            Assert.That(_data.Connections, Does.Not.Contain(connection));
            _mockDatabase.Verify(db => db.Save(_data), Times.Once);
        }

        [Test]
        public void Update_ShouldModifyExistingConnection()
        {
            var connection = new Connection { Id = Guid.NewGuid(), IntegratedSecurity = true, Password = "p1", Server = "s1", Username = "u1" };
            _data.Connections.Add(connection);
            var updatedConnection = new Connection { Id = connection.Id, IntegratedSecurity = false, Password = "p2", Server = "s2", Username = "u2" };

            _repository.Update(updatedConnection);

            Assert.That(_data.Connections.First(c => c.Id == connection.Id).Server, Is.EqualTo("s2"));
            Assert.That(_data.Connections.First(c => c.Id == connection.Id).Password, Is.EqualTo("p2"));
            Assert.That(_data.Connections.First(c => c.Id == connection.Id).Username, Is.EqualTo("u2"));
            _mockDatabase.Verify(db => db.Save(_data), Times.Once);
        }

        private static void AssertConnections(Connection expected, Connection actual)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.Id, Is.EqualTo(expected.Id));
                Assert.That(actual.IntegratedSecurity, Is.EqualTo(expected.IntegratedSecurity));
                Assert.That(actual.Password, Is.EqualTo(expected.Password));
                Assert.That(actual.Server, Is.EqualTo(expected.Server));
                Assert.That(actual.Username, Is.EqualTo(expected.Username));
            });
        }
    }
}
