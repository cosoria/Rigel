using System.Collections.Generic;

namespace Rigel.Batch.Common.Mail
{
    public interface IMailMessage
    {
        string Subject { get; }
        string Body { get; }
        string Sender { get; }
        IList<string> Recipients { get; }
        bool IsBodyHtml { get; set; }

        /// <summary>
        /// Parse a CSV or semi-colon seperated list of recipients.
        /// </summary>
        MailMessage SetRecipients(string recipients);
        MailMessage SetSubject(string subject);
        MailMessage SetBody(string body);

        System.Net.Mail.MailMessage GetAsMailMessage();
    }
}