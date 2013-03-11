using System;
using System.IO;
using Rigel.Batch.Common.Config;
using Rigel.Batch.Common.Mail;
using Rigel.Logging;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Rigel.Batch.Common
{
    public class BatchEmailService
    {
        private readonly string _batchName;
        private readonly bool _enabled;
        private readonly int _emailLevel;
        private readonly string _emailSender;
        private readonly string _emailRecipients;

        private readonly IPostmaster _notificationService;
        private readonly ILogger _logger;

        private BatchEmailService(string batchName, bool enabled, int emailLevel, string emailSender, string emailRecipients)
        {
            _batchName = batchName;
            _enabled = enabled;
            _emailLevel = emailLevel;
            _emailSender = emailSender;
            _emailRecipients = emailRecipients;

            // todo ioc
            _notificationService = Postmaster.Instance;
            _logger = new ConsoleLogger();
        }

        public void SendBatchResultNotification()
        {
            if(!_enabled || ShouldSendEmailFor(ReturnCode.Instance.Value) == false)
            {
                return;
            }

            IMailMessage message = GetMessageFor(ReturnCode.Instance.Value);

            try
            {
                _notificationService.Send(message);
            }
            catch(Exception ex)
            {
                try
                {
                    _logger.LogError("Error sending email.  Exception details: " + ex);       
                }
                catch(Exception emailException)
                {
                    Console.WriteLine("Error sending email for exception");
                    Console.WriteLine("Original exception: " + ex);
                    Console.WriteLine("Email exception: " + emailException);
                }
            }
        }

        private bool ShouldSendEmailFor(int returnCode)
        {
            if(_emailLevel == BatchConstants.ERROR_LEVEL) // fail
            {
                return returnCode == ReturnCodeValue.Failure;
            }
            else if (_emailLevel == BatchConstants.WARNING_LEVEL) // partial fail
            {
                return returnCode > ReturnCodeValue.Success;
            }
            else
            {
                return true;
            }
        }

        private IMailMessage GetMessageFor(int returnCode)
        {
            string body = LoadBodyFromLogFile();

            switch(returnCode)
            {
                case ReturnCodeValue.Failure:
                case ReturnCodeValue.PartialFailure:
                    return MailMessage.CreateFor(_emailSender, _emailRecipients)
                        .SetSubject(_batchName + " failed").SetBody(body);
                case ReturnCodeValue.Success:
                    return MailMessage.CreateFor(_emailSender, _emailRecipients)
                        .SetSubject(_batchName + " ran successfully").SetBody(body);
                default:
                    throw new InvalidOperationException("Unknow batch result");
            }
        }

        private static string LoadBodyFromLogFile()
        {
            string body = "Could not find log to attach.  See logs for information.";
            string logFile = ConfigurationManager.AppSettings[BatchConstants.LOGS_FILE];

            logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFile); 

            if (File.Exists(logFile))
            {
                using(var streamReader = new StreamReader(logFile))
                {
                    body = streamReader.ReadToEnd();
                }
            }
            return body;
        }

        public static BatchEmailService Create(string batchName, IErrorNotificationSettings arguments)
        {
            return new BatchEmailService(batchName, 
                arguments.NotificationSettings.enabled,
                ConfigurationConstants.GetErrorLevelFor(arguments.NotificationSettings.level), 
                arguments.NotificationSettings.sender, 
                arguments.NotificationSettings.recipients);
        }
    }
} 