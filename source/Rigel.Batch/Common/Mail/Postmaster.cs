using System;
using System.Net;
using System.Net.Mail;
using Rigel.Batch.Common.Config;
using Rigel.Logging;

namespace Rigel.Batch.Common.Mail
{
    public class Postmaster : IPostmaster
    {
        private static IPostmaster _postmaster;
        private readonly IConfigurationManager _configurationManager;
        private readonly ILogger _logger;
        private static NetworkCredential _networkCredential;

        private Postmaster()
            : this(ConfigurationManager.Instance, new ConsoleLogger())
        {
        }

        public Postmaster(IConfigurationManager configurationManager, ILogger logger)
        {
            _configurationManager = configurationManager;
            _logger = logger;
        }

        public static IPostmaster Instance
        {
            get
            {
                if(_postmaster == null)
                {
                    _postmaster = new Postmaster();
                    _postmaster.Initialize();
                }
                return _postmaster;           
            }
        }

        public void Initialize()
        {
            var errorNotificationSettings = _configurationManager.ErrorNotificationSettings;

            if (errorNotificationSettings != null)
            {
                var smtpSettings = errorNotificationSettings.SmtpSettings;

                _networkCredential = new NetworkCredential(smtpSettings.username, smtpSettings.password);
            }
        }

        public bool Send(IMailMessage message)
        {
            try
            {
                var smtpSettings = _configurationManager.ErrorNotificationSettings.SmtpSettings;

                var mailClient = new SmtpClient(smtpSettings.server, smtpSettings.port)
                                            {
                                                EnableSsl = true,
                                                Credentials = _networkCredential
                                            };

                mailClient.Send(message.GetAsMailMessage());
            }
            catch (Exception ex)
            {
                _logger.LogError("Error sending email.  Exception details: " + ex);
                return false;
            }
            return true;
        }
    }
}