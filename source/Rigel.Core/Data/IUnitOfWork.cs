using System;

namespace Rigel.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}