using Chinook.DataAccess.Repositories;
using Chinook.DataAccess.Repositories.All;
using Chinook.DataAccess.Test.Context;
using NUnit.Framework;


// ReSharper disable InconsistentNaming
namespace Chinook.DataAccess.Test.Respositories
{
    [TestFixture]
    public class CustomerRepositoryTest
    {
        [Test]
        public void Can_Create_Repo()
        {
            var repo = new CustomerRepository(new TestUnitOfWork());

            Assert.That(repo, Is.Not.Null);
        }
    }
}