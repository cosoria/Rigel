namespace Rigel.Batch.Arguments.Attributes.Customized.String
{
    public class EmailSenderAttribute : StringAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "Sender";
        private const string HELP_TEXT = "From email sender.";
        private const string INVALID_VALUE = "'{0}' is not a valid email sender.";

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