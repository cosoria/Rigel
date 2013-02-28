using System.Configuration;

namespace Rigel.Batch.Common.Config
{
    public interface IErrorNotificationSettings
    {
        SmtpSettingsElement SmtpSettings { get; set; }
        NotificationSettingsElement NotificationSettings { get; set; }
    }

    public class ErrorNotificationSettings : ConfigurationSection, IErrorNotificationSettings
    {
        [ConfigurationProperty("SmtpSettings", IsRequired = true)]
        public SmtpSettingsElement SmtpSettings
        {
            get { return base["SmtpSettings"] as SmtpSettingsElement; }
            set { base["SmtpSettings"] = value; }
        }

        [ConfigurationProperty("NotificationSettings", IsRequired = true)]
        public NotificationSettingsElement NotificationSettings
        {
            get { return base["NotificationSettings"] as NotificationSettingsElement; }
            set { base["NotificationSettings"] = value; }
        }
    }
}