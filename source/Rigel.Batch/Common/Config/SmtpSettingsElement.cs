using System.Configuration;

namespace Rigel.Batch.Common.Config
{
    public interface ISmtpSettings
    {
        string server { get; set; }
        int port { get; set; }
        string username { get; set; }
        string password { get; set; }
    }

    public class SmtpSettingsElement : ConfigurationElement, ISmtpSettings
    {
        [ConfigurationProperty("server", IsRequired = true)]
        public string server
        {
            get { return (string)base["server"]; }
            set { base["server"] = value; }
        }
        [ConfigurationProperty("port", IsRequired = true)]
        public int port
        {
            get { return (int)base["port"]; }
            set { base["port"] = value; }
        }
        [ConfigurationProperty("username", IsRequired = true)]
        public string username
        {
            get { return (string)base["username"]; }
            set { base["username"] = value; }
        }
        [ConfigurationProperty("password", IsRequired = true)]
        public string password
        {
            get { return (string)base["password"]; }
            set { base["password"] = value; }
        }
    }
}