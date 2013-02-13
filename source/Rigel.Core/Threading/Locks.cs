using System.Threading;

namespace Rigel.Core.Threading
{
    public sealed class Locks
    {
        public static ReaderWriterLockSlim GetLockInstance()
        {
            return GetLockInstance(LockRecursionPolicy.SupportsRecursion);
        }

        public static ReaderWriterLockSlim GetLockInstance(LockRecursionPolicy policy)
        {
            return new ReaderWriterLockSlim(policy);
        }

        public static void GetReadLock(ReaderWriterLockSlim lockObject)
        {
            var lockAcquired = false;
            while (!lockAcquired)
            {
                lockAcquired = lockObject.TryEnterUpgradeableReadLock(1); 
            }
        }
        
        public static void GetReadOnlyLock(ReaderWriterLockSlim lockObject)
        {
            var lockAcquired = false;
            while (!lockAcquired)
            {
                lockAcquired = lockObject.TryEnterReadLock(1);
            }
        }

        public static void GetWriteLock(ReaderWriterLockSlim lockObject)
        {
            var lockAcquired = false;
            while (!lockAcquired)
            {
                lockAcquired = lockObject.TryEnterWriteLock(1);
            }
        }

        public static void ReleaseReadLock(ReaderWriterLockSlim lockObject)
        {
            if (lockObject.IsReadLockHeld)
            {
                lockObject.ExitReadLock();
            }
        }

        public static void ReleaseReadOnlyLock(ReaderWriterLockSlim lockObject)
        {
            if (lockObject.IsUpgradeableReadLockHeld)
            {
                lockObject.ExitUpgradeableReadLock();
            }
        }
        
        public static void ReleaseWriteLock(ReaderWriterLockSlim lockObject)
        {
            if (lockObject.IsWriteLockHeld)
            {
                lockObject.ExitWriteLock();
            }
        }

        public static void ReleaseLocks(ReaderWriterLockSlim lockObject)
        {
            ReleaseWriteLock(lockObject);
            ReleaseReadLock(lockObject);
            ReleaseReadOnlyLock(lockObject);
        }
    }
}