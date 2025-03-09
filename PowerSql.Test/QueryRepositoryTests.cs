using Moq;
using PowerSql.UI.Database;
using PowerSql.UI.Domain.Models;
using PowerSql.UI.Domain.Repositories;

namespace PowerSql.Test
{
    [TestFixture]
    public class QueryRepositoryTests
    {
        private Mock<IDatabase> _mockDatabase;
        private QueryRepository _repository;
        private ApplicationData _data;

        [SetUp]
        public void Setup()
        {
            _mockDatabase = new Mock<IDatabase>();
            _repository = new QueryRepository(_mockDatabase.Object);
            _data = new ApplicationData { Queries = [] };
            _mockDatabase.Setup(db => db.Read()).Returns(_data);
        }

        [Test]
        public void Add_ShouldAddQuery()
        {
            var query = new Query { Id = Guid.NewGuid(), Name = "TestQuery", Sql = "SELECT * FROM Test" };

            _repository.Add(query);

            Assert.That(_data.Queries, Does.Contain(query));
            _mockDatabase.Verify(db => db.Save(_data), Times.Once);
        }

        [Test]
        public void Get_ShouldReturnQueryById()
        {
            var query = new Query { Id = Guid.NewGuid(), Name = "TestQuery", Sql = "SELECT * FROM Test" };
            _data.Queries.Add(query);

            var result = _repository.Get(query.Id);

            AssertQueries(query, result);
        }

        [Test]
        public void GetAll_ShouldReturnAllQueries()
        {
            var query1 = new Query { Id = Guid.NewGuid(), Name = "TestQuery1", Sql = "SELECT * FROM Test1" };
            var query2 = new Query { Id = Guid.NewGuid(), Name = "TestQuery2", Sql = "SELECT * FROM Test2" };
            _data.Queries.AddRange([query1, query2]);

            var result = _repository.GetAll();

            Assert.That(result, Has.Count.EqualTo(2));
            Assert.That(result, Does.Contain(query1));
            Assert.That(result, Does.Contain(query2));
        }

        [Test]
        public void Update_ShouldModifyExistingQuery()
        {
            var query = new Query { Id = Guid.NewGuid(), Name = "TestQuery", Sql = "SELECT * FROM Test" };
            _data.Queries.Add(query);
            var updatedQuery = new Query { Id = query.Id, Name = "UpdatedQuery", Sql = "SELECT * FROM UpdatedTest" };

            _repository.Update(updatedQuery);

            Assert.That(_data.Queries.First(q => q.Id == query.Id).Name, Is.EqualTo("UpdatedQuery"));
            _mockDatabase.Verify(db => db.Save(_data), Times.Once);
        }

        private void AssertQueries(Query expected, Query actual)
        {
            Assert.Multiple(() =>
            {
                Assert.That(actual.Id, Is.EqualTo(expected.Id));
                Assert.That(actual.Name, Is.EqualTo(expected.Name));
                Assert.That(actual.Sql, Is.EqualTo(expected.Sql));
            });
        }
    }
}
