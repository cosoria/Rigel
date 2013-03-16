using System;

namespace Rigel.Data
{
    public interface IDataContext : IDisposable
    {
        void Save();
    }
}