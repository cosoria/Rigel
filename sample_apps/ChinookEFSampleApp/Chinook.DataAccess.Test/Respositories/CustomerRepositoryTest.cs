using Chinook.DataAccess.Repositories.All;
using Chinook.DataAccess.Test.Context;
using NUnit.Framework;
using Rigel.Data.EntityFramewok;


// ReSharper disable InconsistentNaming
namespace Chinook.DataAccess.Test.Respositories
{
    [TestFixture]
    public class CustomerRepositoryTest
    {
        [Test]
        public void Can_Create_Repo()
        {
            var repo = new CustomerRepository(new EntityFrameworkUnitOfWork<ChinookTestContext>());

            Assert.That(repo, Is.Not.Null);
        }
    }
}