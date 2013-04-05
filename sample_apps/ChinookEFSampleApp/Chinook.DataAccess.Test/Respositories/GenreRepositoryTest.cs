using System.Configuration;
using System.Linq;
using Chinook.DataAccess.Context.All;
using Chinook.DataAccess.Repositories.All;
using Chinook.Entities;
using NUnit.Framework;
using Rigel.Data.EntityFramewok;

// ReSharper disable InconsistentNaming
namespace Chinook.DataAccess.Test.Respositories
{
    [TestFixture]
    public class GenreRepositoryTest
    {
        private const string GenreRock = "RockForTesting";
        private const string GenreJazz = "JazzForTesting";
        private const string GenreLatin = "LatinForTesting";
        private const string GenreMetal = "MetalForTesting";


        public GenreRepositoryTest()
        {
        }


        [Test]
        public void Can_Add()
        {
            SeedDatabase();

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                repo.Add(new Genre { GenreId = 600, Name = "Test"});

                uow.Save();
            }

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                var testGenre = repo.Get(600);

                Assert.That(testGenre, Is.Not.Null);
                Assert.That(testGenre.GenreId, Is.EqualTo(600));
                Assert.That(testGenre.Name, Is.EqualTo("Test"));
            }
        }

        [Test]
        public void Can_Update()
        {
            SeedDatabase();

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                var testGenre = repo.Get(100);
                testGenre.Name = "Test Name";
                
                uow.Save();
            }

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                var testGenre = repo.Get(100);

                Assert.That(testGenre, Is.Not.Null);
                Assert.That(testGenre.Name, Is.EqualTo("Test Name"));
            }
        }

        [Test]
        public void Can_Delete()
        {
            SeedDatabase();

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                repo.Delete(100);

                uow.Save();
            }

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                var testGenre = repo.Get(100);

                Assert.That(testGenre, Is.Null);
            }
        }

        [Test]
        public void Can_GetAll()
        {
            SeedDatabase();

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                var allGenres = repo.GetAll();
                
                Assert.That(allGenres.Count(), Is.EqualTo(29));
            }
        }

        [Test]
        public void Can_GetAll_Matching()
        {
            SeedDatabase();

            using (var uow = new EntityFrameworkUnitOfWork<ChinookAllEntitiesContext>())
            {
                var repo = new GenreRepository(uow);
                var rockGenres = repo.GetAllMatching(g => g.Name.Contains("Rock"));

                Assert.That(rockGenres.Count(), Is.EqualTo(3));
            }
        }
        
        private void SeedDatabase()
        {
            var db = new SQLiteDB(GetConnString());

            db.Execute("DELETE FROM [Genre] WHERE [GenreId] > 99;");

            db.Add("INSERT INTO [Genre] ([GenreId], [Name]) VALUES (@GenreId, @Name);", new Genre { GenreId = 100, Name = GenreRock });
            db.Add("INSERT INTO [Genre] ([GenreId], [Name]) VALUES (@GenreId, @Name);", new Genre { GenreId = 200, Name = GenreJazz });
            db.Add("INSERT INTO [Genre] ([GenreId], [Name]) VALUES (@GenreId, @Name);", new Genre { GenreId = 300, Name = GenreLatin });
            db.Add("INSERT INTO [Genre] ([GenreId], [Name]) VALUES (@GenreId, @Name);", new Genre { GenreId = 400, Name = GenreMetal });
        }

        private string GetConnString()
        {
            return ConfigurationManager.ConnectionStrings["ChinookContext"].ConnectionString;
        }
    }
}