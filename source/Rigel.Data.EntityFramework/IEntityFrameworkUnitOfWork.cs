namespace Rigel.Data.EntityFramewok
{
    public interface IEntityFrameworkUnitOfWork : IUnitOfWork
    {
        IEntityFrameworkContext Context { get; }
    }
}