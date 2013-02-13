using System;

namespace Rigel.Core.Logging
{
    public interface ILoggerFactory
    {
        ILogger Create();
        ILogger Create(object instance);
        ILogger Create(Type instanceType);
    }
}