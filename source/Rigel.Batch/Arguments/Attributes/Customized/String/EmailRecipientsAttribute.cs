namespace Rigel.Batch.Arguments.Attributes.Customized.String
{
    public class EmailRecipientsAttribute : StringAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "MailRecipients";
        private const string HELP_TEXT = "Email recipients.";
        private const string INVALID_VALUE = "'{0}' is not a valid email recipient (list).";

        #endregion

        #region Property overrides

        public override string HelpText
        {
            get { return HELP_TEXT; }
        }

        public override string InvalidValueText
        {
            get { return INVALID_VALUE; }
        }

        public override string ConfigurationKey
        {
            get { return CONFIG_KEY; }
        }

        #endregion
    }
}