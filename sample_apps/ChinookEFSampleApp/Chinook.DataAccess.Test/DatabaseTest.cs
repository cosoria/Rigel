using System;
using System.Configuration;
using System.IO;
using System.Linq;
using Chinook.DTO;
using Chinook.DataAccess.Test.Context;
using NUnit.Framework;

// ReSharper disable InconsistentNaming
namespace Chinook.DataAccess.Test
{
    [TestFixture]
    public class DatabaseTest
    {
        private readonly string basePath;
        private readonly string databaseFilePath;

        private const string GenreRock = "RockForTesting";
        private const string GenreJazz = "JazzForTesting";
        private const string GenreLatin = "LatinForTesting";
        private const string GenreMetal = "MetalForTesting";
        
        public DatabaseTest()
        {
            basePath = Environment.CurrentDirectory;
            databaseFilePath = Path.Combine(basePath, ".\\Database\\Chinook_Sqlite.sqlite");
        }

        [Test]
        public void Can_Open_DataBase()
        {
            using (var ctx = new ChinookTestContext())
            {
                Assert.That(ctx.Database.Exists(), Is.True);
            }
        }

        [Test]
        public void Can_Insert_Data()
        {
            using (var ctx = new ChinookTestContext())
            {
                ctx.Genres.Add(new Genre {GenreId = 500, Name = "LoloForTesting" });
                ctx.SaveChanges();
            }

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.SingleOrDefault(x => x.GenreId == 500);

                Assert.That(g, Is.Not.Null);
                Assert.That(g.Name, Is.EqualTo("LoloForTesting"));
            }
        }

        [Test]
        public void Can_Update_Data()
        {
            SeedDatabase();

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.SingleOrDefault(x => x.Name == GenreLatin);
                g.Name = "LoloForTesting";

                ctx.SaveChanges();
            }

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.SingleOrDefault(x => x.Name == "LoloForTesting");
                Assert.That(g, Is.Not.Null);
            }
        }

        [Test]
        public void Can_Delete_Data()
        {
            SeedDatabase();

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.SingleOrDefault(x => x.Name == GenreJazz);
                
                ctx.MarkAsDeleted(g);
                ctx.SaveChanges();
            }

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.SingleOrDefault(x => x.Name == GenreJazz);
                Assert.That(g, Is.Null);
            }
        }

        [Test]
        public void Can_Query_Data()
        {
            SeedDatabase();

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.Single(x => x.Name == GenreJazz);

                Assert.That(g, Is.Not.Null);
            }

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.SingleOrDefault(x => x.GenreId == 1);

                Assert.That(g, Is.Not.Null);
            }

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.FirstOrDefault(x => x.GenreId == 100 && x.Name == GenreRock);

                Assert.That(g, Is.Not.Null);
            }

            using (var ctx = new ChinookTestContext())
            {
                var g = ctx.Genres.Where(x => x.GenreId > 200);

                Assert.That(g, Is.Not.Empty);
            }

            using (var ctx = new ChinookTestContext())
            {
                var total = ctx.Genres.Count(x => x.GenreId > 99);

                Assert.That(total, Is.EqualTo(4));
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