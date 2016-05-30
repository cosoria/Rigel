using System;

namespace Rigel.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}