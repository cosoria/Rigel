﻿using System.Threading;

namespace Rigel.Core.Threading
{
    public class ReadLock: BaseLock
    {
        public ReadLock(ReaderWriterLockSlim lockObject) : base(lockObject)
        {
            Locks.GetReadLock(_lockObject);
        }

        public override void Dispose()
        {
            Locks.ReleaseReadLock(_lockObject);
        }
    }
}