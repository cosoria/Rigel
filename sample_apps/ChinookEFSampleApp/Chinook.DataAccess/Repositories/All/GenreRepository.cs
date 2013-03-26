using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Chinook.DataAccess.Context.All;
using Chinook.Entities;
using Rigel.Core;
using Rigel.Data;
using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Repositories.All
{

    public interface IGenreRepository : IRepository<Genre>
    {
    }

    public class GenreRepository : IGenreRepository
    {
        private readonly IChinookAllEntitiesContext _context;

        public GenreRepository(IEntityFrameworkUnitOfWork uow)
        {
            _context = uow.Context as IChinookAllEntitiesContext;
            Ensure.NotNull(() => _context);
        }

        public Genre Get(object key)
        {
            return _context.Genres.Find(key);
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToArray();
        }

        public IEnumerable<Genre> GetAllMatching(Expression<Func<Genre, bool>> filter)
        {
            return _context.Genres.Where(filter).ToArray();
        }

        public void Add(Genre entry)
        {
            _context.MarkAsAdded(entry);
        }

        public void Delete(object key)
        {
            var entry = Get(key);
            _context.MarkAsDeleted(entry);
        }

        public void Update(Genre entry)
        {
            _context.MarkAsModified(entry);
        }
    }
}