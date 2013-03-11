using System;
using System.Collections.Generic;
using System.Reflection;
using Rigel.Batch.Arguments.Attributes;
using Rigel.Batch.Common;
using Rigel.Core;
using Rigel.Logging;

namespace Rigel.Batch
{
    /// <summary>
    /// Contains the common process of determining and binding arguments.
    /// </summary>
    public class BaseLauncher
    {
        private static readonly ILogger _logger = new ConsoleLogger(); // todo inject with ioc

        #region Variables

        protected static IDictionary<Type, string> _arguments;
        protected static Assembly _assembly;
        protected static string _executableName;
        protected static IBatchApplication _application = null;
        protected static Dictionary<string, Type> _processorTypes;

        #endregion

        protected static void LaunchBatchProcess()
        {
            if((_application != null) && (!ReturnCode.Instance.HasFailed()))
            {
                _application.InvokeBatch();
            }
        }

        #region Command line parsing/binding

        protected static void ParseCommandLineArguments(string[] args)
        {
            _arguments = ArgumentParser.DetermineArgumentTypes(args);
        }

        protected static void BindArguments()
        {
            var errors = ArgumentBinder.BindArguments(_arguments, _application);

            LogArguments();
            LogBindErrors(errors);
        }

        #endregion

        #region Logging

        protected static void LogBindErrors(List<string> errors)
        {
            Ensure.Argument.NotNull(() => errors);
            if(errors.Count > 0)
            {
                EpicFail("There was one or more errors with the arguments:");
                EpicFail("------------------------------------------------");

                foreach(string error in errors)
                {
                    EpicFail(error);
                }

                EpicFail("------------------------------------------------");
            }
        }

        public static void LogArguments()
        {
            _logger.LogInfo("The following arguments were passed:");
            _logger.LogInfo("------------------------------------");

            foreach (KeyValuePair<Type, string> arg in _arguments)
            {
                string argumentName =
                    arg.Key.ToString().Substring(arg.Key.ToString().LastIndexOf(".") + 1).Replace("Attribute",
                                                                                                  string.Empty);
                string output = string.Format("{0} = {1}", argumentName, arg.Value);
                _logger.LogInfo(output);
            }

            _logger.LogInfo("------------------------------------\r\n");
        }

        protected static void EpicFail(string message)
        {
            Console.WriteLine(message);

            if(_application != null)
            {
                //_application.ExternalLogger.Info(message);
            }

            ReturnCode.Instance.Fail();
        }

        #endregion
    }
}