namespace Rigel.Batch.Arguments.Attributes.Customized.String
{
    public class BatchNameAttribute : StringAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "n/a";
        private const string HELP_TEXT = "The batch job to launch.";
        private const string INVALID_VALUE = "n/a";

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