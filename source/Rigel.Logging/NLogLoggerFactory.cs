using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NLog;
using NLog.Config;
using NLog.Targets;
using Rigel.Core.Logging;
using Rigel.Core.Utils;

namespace Rigel.Logging
{
    public class NLogLoggerFactory : ILoggerFactory
    {
        private const string DefaultLogLayout = "${longdate} ${logger} ${message} ${newline} ${exception:format=tostring}";
        private const string DefaultLogArchiveFileName = "log.{#}.txt";
        
        public NLogLoggerFactory()
        {
            if (LogManager.Configuration == null || LogManager.Configuration.AllTargets.Count == 0)
            {
                UseDefaultConfig();
            }
        }

        public ILogger Create()
        {
            return new NLogLogger(LogManager.GetCurrentClassLogger());
        }

        public ILogger Create(object instance)
        {
            return instance == null ? Create() : Create(instance.GetType());
        }

        public ILogger Create(Type instanceType)
        {
            return instanceType == null ? Create() : new NLogLogger(LogManager.GetLogger(instanceType.FullName));
        }

        private void UseDefaultConfig()
        {
            LogManager.Configuration = GetDefaultConfiguration();
        }

        private LoggingConfiguration GetDefaultConfiguration()
        {
            var config = new LoggingConfiguration();
            var fileTarget = GetDefaultFileTarget();
          
            config.AddTarget("file", fileTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));

            return config;
        }

        private Target GetDefaultFileTarget()
        {
            var appName = Assembly.GetEntryAssembly().FullName.Split(',').First();
            var logFileName = StringUtil.FormatInvariant("{0}.log.txt", appName);
            var logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), appName);
            var logFilePath = Path.Combine(logPath, logFileName);

            return new FileTarget
                       {
                           FileName = logFilePath,
                           Layout = DefaultLogLayout,
                           ArchiveFileName = appName + "." + DefaultLogArchiveFileName,
                           ArchiveNumbering = ArchiveNumberingMode.Rolling,
                           MaxArchiveFiles = 30,
                           ConcurrentWrites = true,
                           KeepFileOpen = false,
                           ArchiveEvery = FileArchivePeriod.Day
                       };
        }
    }
}