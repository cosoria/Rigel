using System;
using System.Linq;
using NLog;
using NLog.Targets;
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

            var target = LogManager.Configuration.AllTargets.FirstOrDefault() as FileTarget;

            if (target != null)
            {
                Console.Out.WriteLine(String.Format("Review log file at {0} for results", target.FileName));
            }
            
            Console.In.ReadLine();
        }
    }
}
