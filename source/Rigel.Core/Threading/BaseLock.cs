using System;
using System.Threading;

namespace Rigel.Core.Threading
{
    public abstract class BaseLock : IDisposable 
    {
        protected readonly ReaderWriterLockSlim _lockObject;

        protected BaseLock(ReaderWriterLockSlim lockObject)
        {
            _lockObject = lockObject;
        }

        public abstract void Dispose();
    }
}