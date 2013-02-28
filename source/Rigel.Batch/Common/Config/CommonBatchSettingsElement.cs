using System;
using System.Configuration;

namespace Rigel.Batch.Common.Config
{
    public interface ICommonBatchSettings
    {
        string WorkingDirectory { get; set; }
        DateTime? RunAsDate { get; set; }
        bool DownloadData { get; set; }
        bool ClearCache { get; set; }
    }

    public class CommonBatchSettingsElement : ConfigurationElement, ICommonBatchSettings
    {
        [ConfigurationProperty("WorkingDirectory", IsRequired = true)]
        public string WorkingDirectory
        {
            get { return (string)base["WorkingDirectory"]; }
            set { base["WorkingDirectory"] = value; }
        }

        [ConfigurationProperty("RunAsDate", IsRequired = false)]
        public DateTime? RunAsDate
        {
            get { return (DateTime?)base["RunAsDate"]; }
            set { base["RunAsDate"] = value; }
        }

        [ConfigurationProperty("DownloadData", IsRequired = true)]
        public bool DownloadData
        {
            get { return (bool)base["DownloadData"]; }
            set { base["DownloadData"] = value; }
        }

        [ConfigurationProperty("ClearCache", IsRequired = true)]
        public bool ClearCache
        {
            get { return (bool)base["ClearCache"]; }
            set { base["ClearCache"] = value; }
        }
    }
}