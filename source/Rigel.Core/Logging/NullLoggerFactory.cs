using System;

namespace Rigel.Core.Logging
{
    public class NullLoggerFactory : ILoggerFactory
    {
        public ILogger Create()
        {
            return new NullLogger();
        }

        public ILogger Create(object instance)
        {
            return Create();
        }

        public ILogger Create(Type instanceType)
        {
            return Create();
        }
    }
}