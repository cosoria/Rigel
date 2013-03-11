using System;
using System.IO;
using Rigel.Batch.Arguments;
using Rigel.Batch.Common;
using Rigel.Batch.Common.Config;
using Rigel.Core;
using Rigel.Logging;

namespace Rigel.Batch
{
    /// <summary>
    /// Taking pieces of UnitOfWorkApplication from RhinoCommons.
    /// </summary>
    public abstract class BaseBatchApplication : Disposable, IBatchApplication  //,IContainerAccessor 
    {
        private const string BACKUP_PREFIX = "backup_";
        
        public const string CurrentLongConversationKey = "CurrentLongConversation.Key";
        public const string CurrentNHibernateSessionKey = "CurrentNHibernateSession.Key";

        private FileSystemWatcher watcher;
        protected string _batchName;

        public abstract CommonBatchArguments BatchArguments { get; }

        public abstract string BatchName { get; }

        public int InvokeBatch()
        {
            try
            {
                if(ReturnCode.Instance.HasFailed() == false)
                {
                    //InitializeContainer(this);
                    PrepareBatch();
                    RunBatch();
                    ApplicationEnd();
                }
            }
            catch(Exception ex)
            {
                try
                {
                    Logger.LogError(ex.ToString());
                }
                catch
                {
                
                }
                finally
                {
                    ReturnCode.Instance.Fail();
                }
            }

            var batchEmailService = BatchEmailService.Create(BatchName, ConfigurationManager.Instance.ErrorNotificationSettings);
            batchEmailService.SendBatchResultNotification();

            return ReturnCode.Instance.Value;
        }

        public abstract void RunBatch();

        /// <summary>
        /// TODO Move to seperate class
        /// TODO use config file values
        /// </summary>
        protected void PrepareBatch()
        {
            string backupDirectory = BACKUP_PREFIX + DateTime.Now.ToString("yyyyMMddhhmm");

            if(!string.IsNullOrEmpty(BatchArguments.WorkingDirectory))
            {
                backupDirectory = Path.Combine(BatchArguments.WorkingDirectory, backupDirectory);
            }

            if (Directory.Exists(backupDirectory))
            {
                Logger.LogInfo("Deleting directory {0}", backupDirectory);
                Directory.Delete(backupDirectory, true);
            }

            Directory.CreateDirectory(backupDirectory);

            BackupFiles(backupDirectory);
            BackupDirectories(backupDirectory);
        }

        private void BackupDirectories(string backupDirectory)
        {
            foreach (var directory in Directory.GetDirectories(BatchArguments.WorkingDirectory))
            {
                string lastDir = GetLastPartOfPathFor(directory);

                if (lastDir.ToUpper() == "DATA" ||
                    lastDir.StartsWith(BACKUP_PREFIX) ||
                    lastDir.StartsWith("_") ||
                    lastDir == "logs") continue;

                string to = Path.Combine(backupDirectory, GetLastPartOfPathFor(directory));

                Logger.LogInfo("Moving {0} to {1}", directory, to);
                Directory.Move(directory, to);
            }
        }

        private void BackupFiles(string backupDirectory)
        {
            foreach (var file in Directory.GetFiles(BatchArguments.WorkingDirectory))
            {
                string to = Path.Combine(backupDirectory, GetLastPartOfPathFor(file));

                if(file.StartsWith("_"))
                {
                    Logger.LogInfo("Copying {0} to {1}", file, to);
                    File.Copy(file, to);
                }
                else if (file.EndsWith(".exe") || file.EndsWith("roto_list.csv") ||
                         file.EndsWith("season.csv") ||
                         file.EndsWith("hibernate.cfg.xml") || 
                         file.EndsWith(".config") || file.EndsWith(".xml") ||
                         file.EndsWith(".pdb") || file.EndsWith(".dll"))
                {
                    continue;
                }
                else
                {
                    Logger.LogInfo("Moving {0} to {1}", file, to);
                    File.Move(file, to);
                }
            }
        }

        private static string GetLastPartOfPathFor(string path)
        {
            if(path.Contains(@"\"))
            {
                return path.Substring(path.LastIndexOf(@"\")+1);
            }
            return path;
        }

        //public IWindsorContainer Container
        //{
        //    get
        //    {
        //        if (IoC.IsInitialized == false)
        //            InitializeContainer(this);
        //        return IoC.Container;
        //    }
        //}

        public ILogger Logger
        {
            get { return new ConsoleLogger(); } // todo ioc
        }

        //[MethodImpl(MethodImplOptions.Synchronized)]
        //private static void InitializeContainer(BaseBatchApplication self)
        //{
        //    if (IoC.IsInitialized)
        //        return;

        //    self.CreateContainer();
        //}

        public void ApplicationEnd()
        {
            if (ReturnCode.Instance.HasFailed())
            {
                Logger.LogError("Batch failed");
            }
            else
            {
                Logger.LogInfo("Batch successful");
            }

            const string logsDir = @"logs";

            if (Directory.Exists(logsDir) == false)
            {
                Logger.LogError("Could not cleanup logs directory because it doesnt exist.");
            }
            else
            {
                foreach (var file in Directory.GetFiles(logsDir))
                {
                    string to = Path.Combine(BatchArguments.WorkingDirectory, GetLastPartOfPathFor(file));

                    // dont log locking out
                    //Log.For<BaseBatchApplication>().Info("Moving {0} to {1}", file, to);

                    File.Move(file, to);
                }
            }

            //if (Container != null) //can happen if this isn't the first app
            //{
            //    IoC.Reset(Container);
            //    Container.Dispose();
            //}
        }


        protected override void DisposeManagedResources()
        {
            if (watcher != null)
            {
                watcher.Dispose();
            }
        }
        
        //private void CreateContainer()
        //{
        //    var windsorConfig = GetWindsorConfig();

        //    FileSystemEventHandler resetIoC = delegate { IoC.Reset(); };
        //    watcher = new FileSystemWatcher(Path.GetDirectoryName(windsorConfig)) {Filter = Path.GetFileName(windsorConfig)};
        //    watcher.Created += resetIoC;
        //    watcher.Changed += resetIoC;
        //    watcher.Deleted += resetIoC;

        //    IWindsorContainer container = CreateContainer(windsorConfig);
        //    IoC.Initialize(container);

        //    watcher.EnableRaisingEvents = true;
        //}

        private static string GetWindsorConfig()
        {
            string windsorConfig = "Windsor.config"; // Rhino.Commons.Settings.Default.WindsorConfig;

            if (!Path.IsPathRooted(windsorConfig))
            {
                //In ASP.Net apps, the current directory and the base path are NOT the same.
                windsorConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, windsorConfig);
            }

            string[] extensions = { ".config", ".boo" };
            foreach (string extension in extensions)
            {
                string path = windsorConfig + extension;
                if (File.Exists(path))
                {
                    windsorConfig = path;
                    break;
                }
            }
            return windsorConfig;
        }

        //protected virtual IWindsorContainer CreateContainer(string windsorConfig)
        //{
        //    return new RhinoContainer(windsorConfig);
        //}
    }
}