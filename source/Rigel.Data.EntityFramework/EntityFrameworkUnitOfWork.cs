namespace Rigel.Data.EntityFramewok
{
    public class EntityFrameworkUnitOfWork : IEntityFrameworkUnitOfWork
    {
        private readonly IEntityFrameworkContext _context;
        
        public IEntityFrameworkContext Context
        {
            get { return _context; }
        }

        public EntityFrameworkUnitOfWork(IEntityFrameworkContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.Save();
        }
    }
}