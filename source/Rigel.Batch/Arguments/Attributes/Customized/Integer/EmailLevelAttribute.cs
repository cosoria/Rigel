namespace Rigel.Batch.Arguments.Attributes.Customized.Integer
{
    public class EmailLevelAttribute : IntegerAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "EmailLevel";
        private const string HELP_TEXT = "Email notification level. 0=Disabled, 1=Always send, 2=Send on partial failure, 3=Send on failure";
        private const string INVALID_VALUE = "'{0}' is not a email notification level.  0=Disabled, 1=Always send, 2=Send on partial failure, 3=Send on failure.";

        #endregion

        #region Constructors

        public EmailLevelAttribute(bool required) : base(required)
        {
        }

        public EmailLevelAttribute(int? min, int? max, bool required)
            : base(min, max, required)
        {
        }

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

        public override string OutOfRangeMessage
        {
            get
            {
                return "Email leve out of range.  Set as 0=Disabled, 1=Always send, 2=Send on partial failure, 3=Send on failure";
            }
        }
    }
}