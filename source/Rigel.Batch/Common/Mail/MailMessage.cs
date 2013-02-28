using System.Collections.Generic;
using System.Net.Mail;
using Rigel.Batch.Common.Config;

namespace Rigel.Batch.Common.Mail
{
    public class MailMessage : IMailMessage
    {
        public string Subject { get; private set; }
        public string Body { get; private set; }
        public string Sender { get; private set; }
        public IList<string> Recipients { get; private set; }
        public IList<string> Attachments { get; private set; }
        public bool IsBodyHtml { get; set; }

        private MailMessage(string sender, string recipients)
        {
            Sender = sender;
            LoadMailRecipients(recipients);
            Attachments = new List<string>();
            IsBodyHtml = true;
        }

        public MailMessage() 
            : this(ConfigurationManager.Instance.ErrorNotificationSettings.NotificationSettings.sender, null)
        {
        }

        public static IMailMessage CreateFor(string sender, string recipients)
        {
            return new MailMessage(sender, recipients) { IsBodyHtml = false };
        }

        public System.Net.Mail.MailMessage GetAsMailMessage()
        {
            var message = new System.Net.Mail.MailMessage();

            message.IsBodyHtml = IsBodyHtml;
            message.From = new MailAddress(Sender);

            foreach (string recipient in Recipients)
            {
                message.To.Add(recipient);
            }

            message.Subject = Subject;
            message.Body = Body;

            foreach (var attachment in Attachments)
            {
                message.Attachments.Add(new Attachment(attachment));
            }

            return message;
        }

        public MailMessage SetSubject(string subject)
        {
            Subject = subject;
            return this;
        }

        public MailMessage AddAttachment(string attachement)
        {
            Attachments.Add(attachement);
            return this;
        }

        public MailMessage SetBody(string body)
        {
            Body = body;
            return this;
        }

        /// <summary>
        /// Parse a CSV or semi-colon seperated list of recipients.
        /// </summary>
        /// <param name="recipients">CSV seperated list of recipients</param>
        /// <returns>this</returns>
        public MailMessage SetRecipients(string recipients)
        {
            LoadMailRecipients(recipients);
            return this;
        }

        private void LoadMailRecipients(string recipientString)
        {
            Recipients = new List<string>();

            if(string.IsNullOrEmpty(recipientString)) return;

            recipientString = recipientString.Replace(';', ',');

            string[] recipients = recipientString.Split(new char[] { ',' });

            foreach (var recipient in recipients)
            {
                Recipients.Add(recipient);
            }
        }
    }
}