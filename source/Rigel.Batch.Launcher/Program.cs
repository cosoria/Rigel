using System;
using System.Collections.Generic;
using System.Reflection;
using Rigel.Batch.Arguments.Attributes.Customized.String;
using Rigel.Batch.Common;
using Rigel.SampleBatchApp;

namespace Rigel.Batch.Launcher
{
    public class Program : BaseLauncher
    {
        [STAThread]
        private static int Main(string[] args)
        {
            try
            {
                //System.Diagnostics.Debugger.Launch();
                ParseCommandLineArguments(args);

                if (ReturnCode.Instance.HasFailed())
                {
                    return ReturnCode.Instance.Value;
                }

                DetermineBatchToLoad();

                if (ReturnCode.Instance.HasFailed())
                {
                    return ReturnCode.Instance.Value;
                }

                BindArguments();

                if (ReturnCode.Instance.HasFailed())
                {
                    return ReturnCode.Instance.Value;
                }

                LaunchBatchProcess();
            }
            catch (Exception ex)
            {
                EpicFail("Error:" + ex);
            }

            //Console.ReadLine();
            return ReturnCode.Instance.Value;
        }

        #region Reflection based batch loading

        protected static void DetermineBatchToLoad()
        {
            _executableName = GetExecutableName();

            //var callingAssembly = Assembly.GetCallingAssembly();
            //List<Assembly> allAssemblies = new List<Assembly>();
            //string path = Assembly.GetExecutingAssembly().Location;

            //foreach (string dll in Directory.GetFiles(path, "*.dll"))
            //    allAssemblies.Add(Assembly.LoadFile(dll));

            var type = typeof (SampleBatchApplication); // todo scan Ass

            _assembly = Assembly.GetAssembly(type);
            _processorTypes = LoadProcessorTypes();
            _executableName = GetExecutableName();

            LoadProcessorFrom(_assembly, _executableName, _processorTypes);
        }

        protected static void LoadProcessorFrom(Assembly assembly, string executableName, Dictionary<string, Type> processorTypes)
        {
            if (processorTypes.ContainsKey(executableName))
            {
                if (_application == null)
                {
                    _application = assembly.CreateInstance(processorTypes[executableName].FullName) as IBatchApplication;
                }

                if (_application == null)
                {
                    EpicFail("Error! " + executableName + " is not an instance of IBatchApplication.  Please fix before proceeding.");
                }
            }
            else
            {
                EpicFail("Could not find the correct batch to load!  Please check executable name.");
            }
        }

        protected static Dictionary<string, Type> LoadProcessorTypes()
        {
            Type[] types = _assembly.GetTypes();
            var processorTypes = new Dictionary<string, Type>();

            foreach (Type type in types)
            {
                var batchExecutables = type.GetCustomAttributes(typeof(BatchExecutableAttribute), true) as BatchExecutableAttribute[];

                if ((batchExecutables != null) && (batchExecutables.Length > 0))
                {
                    foreach (BatchExecutableAttribute attribute in batchExecutables)
                    {
                        foreach (string batchName in attribute.BatchNames())
                        {
                            processorTypes.Add(batchName.ToUpper(), type);
                        }
                    }
                }
            }

            return processorTypes;
        }

        protected static string GetExecutableName()
        {
            if (_arguments.ContainsKey(typeof(BatchNameAttribute)))
            {
                string batchName = _arguments[typeof(BatchNameAttribute)];

                if (!string.IsNullOrEmpty(batchName))
                {
                    return batchName.ToUpper();
                }
            }
            else
            {
                var batchNameFromConfiguration = Configuration.GetValue("BatchName");

                if (string.IsNullOrEmpty(batchNameFromConfiguration) == false)
                {
                    return batchNameFromConfiguration.ToUpper();
                }
            }

            return null;
        }

        #endregion
    }
}
