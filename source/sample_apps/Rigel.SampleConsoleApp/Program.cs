using System;
using Rigel.Logging;

namespace Rigel.SampleConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var logFactory = new NLogLoggerFactory();

            var logger = logFactory.Create();

            logger.LogInfo("Logging with NLog"); 

            Console.In.ReadLine();
        }
    }
}
