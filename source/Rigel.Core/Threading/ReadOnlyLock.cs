using System.Threading;

namespace Rigel.Core.Threading
{
    public class ReadOnlyLock : BaseLock
    {
        public ReadOnlyLock(ReaderWriterLockSlim lockObject) : base(lockObject)
        {
            Locks.GetReadOnlyLock(_lockObject);
        }
        
        public override void Dispose()
        {
            Locks.ReleaseReadOnlyLock(_lockObject);
        }
    }
}