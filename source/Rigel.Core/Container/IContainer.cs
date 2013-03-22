using System;

namespace Rigel.Container
{
    public interface IContainer : IDisposable
    {
        TDependency GetInstance<TDependency>();
    }
}