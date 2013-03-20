using Rigel.Data.EntityFramewok;

namespace Chinook.DataAccess.Context.MusicStore
{
    public class MusicStoreUnitOfWork : EntityFrameworkUnitOfWork 
    {
        public MusicStoreUnitOfWork() : base(new ChinookMusicStoreContext())
        {
        }
    }
}