using System.Configuration;

namespace Rigel.Batch.Common.Config
{
    public class NotificationSettingsElement : ConfigurationElement
    {
        [ConfigurationProperty("enabled", IsRequired = true)]
        public bool enabled
        {
            get { return (bool)base["enabled"]; }
            set { base["enabled"] = value; }
        }
        [ConfigurationProperty("level", IsRequired = true)]
        public string level
        {
            get { return (string)base["level"]; }
            set { base["level"] = value; }
        }
        [ConfigurationProperty("sender", IsRequired = true)]
        public string sender
        {
            get { return (string)base["sender"]; }
            set { base["sender"] = value; }
        }
        [ConfigurationProperty("recipients", IsRequired = true)]
        public string recipients
        {
            get { return (string)base["recipients"]; }
            set { base["recipients"] = value; }
        }
        [ConfigurationProperty("subject_prefix", IsRequired = true)]
        public string subject_prefix
        {
            get { return (string)base["subject_prefix"]; }
            set { base["subject_prefix"] = value; }
        }
    }
}