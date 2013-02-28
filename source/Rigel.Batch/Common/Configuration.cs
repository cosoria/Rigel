using System;

namespace Rigel.Batch.Common
{
    public class Configuration
    {
        public static string GetValue(string key)
        {
            if (key.Contains("WorkingDirectory"))// || key == BatchConstants.CommonConfigKeys.ROOT_WORKING_CFG_KEY)
            {
                throw new ArgumentException("Should use GetWorkingDirectory");
            }

            return System.Configuration.ConfigurationManager.AppSettings[key];
        }

        public static string GetWorkingDirectory(string key)
        {
            var appSetting = System.Configuration.ConfigurationManager.AppSettings[key];

            return string.IsNullOrEmpty(appSetting) ? AppDomain.CurrentDomain.BaseDirectory : appSetting;
        }
    }
}