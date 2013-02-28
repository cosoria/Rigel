using System;

namespace Rigel.Batch.Common.Config
{
    public sealed class ConfigurationManager : IConfigurationManager
    {
        private static readonly object _lockObject = new object();

        private ConfigurationManager() { }

        public T GetConfigSetting<T>(string key)
        {
            var setting = System.Configuration.ConfigurationManager.AppSettings[key];

            if (setting == null)
            {
                return default(T);
            }

            return (T)Convert.ChangeType(setting, typeof(T));
        }

        public IErrorNotificationSettings ErrorNotificationSettings
        {
            get
            {
                return System.Configuration.ConfigurationManager.GetSection(
                           ConfigurationConstants.ERROR_NOTIFICATION_SETTINGS_SECTION) as ErrorNotificationSettings;
            }
        }

        public IBatchSettings BatchSettings
        {
            get
            {
                return new BatchSettings(
                    System.Configuration.ConfigurationManager.GetSection(
                           ConfigurationConstants.BATCH_SETTINGS_SECTION) as BatchSettingsSection);
            }
        }

        public static IConfigurationManager Instance
        {
            get
            {
                // Use nested class so its instantiated only once (slight performance gain over repeated lock)
                return Nested.instance;
            }
            set
            {
                lock (_lockObject)
                {
                    Nested.instance = value;
                }
            }
        }

        private static class Nested
        {
            static Nested() { }

            internal static IConfigurationManager instance = new ConfigurationManager();
        }
    }
}