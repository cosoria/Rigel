using Rigel.Core;

namespace Rigel.Data.EntityFramewok
{
    public class EntityFrameworkUnitOfWork<TContext> : Disposable, IEntityFrameworkUnitOfWork where TContext : class, IEntityFrameworkContext, new() 
    {
        private readonly TContext _context;

        public IEntityFrameworkContext Context
        {
            get { return _context; }
        }

        public EntityFrameworkUnitOfWork() :this(new TContext())
        {
        }

        public EntityFrameworkUnitOfWork(TContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.Save();
        }

        protected override void DisposeManagedResources()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}