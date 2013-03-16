namespace Rigel.Data
{
    public interface IUnitOfWork
    {
        IDataContext Context { get; }
        void Save();
    }
}