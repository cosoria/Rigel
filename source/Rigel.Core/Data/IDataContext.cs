using System;

namespace Rigel.Core.Data
{
    public interface IDataContext : IDisposable
    {
        void Save();
    }
}