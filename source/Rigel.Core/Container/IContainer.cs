using System;

namespace Rigel.Core.Container
{
    public interface IContainer : IDisposable
    {
        TDependency Resolve<TDependency>();
    }
}