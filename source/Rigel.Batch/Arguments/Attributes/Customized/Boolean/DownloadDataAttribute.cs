namespace Rigel.Batch.Arguments.Attributes.Customized.Boolean
{
    public class DownloadDataAttribute : BooleanAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "DownloadData";
        private const string HELP_TEXT = "The import all games indicator.  Valid values are 'Y', 'N', 'true' or 'false'";
        private const string INVALID_VALUE = "'{0}' is not a valid DownloadData indicator.  Please specify 'Y', 'N', 'true' or 'false' only.";

        #endregion

        #region Constructors

        public DownloadDataAttribute()
        {
        }

        public DownloadDataAttribute(bool required) : base(required)
        {
        }

        public DownloadDataAttribute(bool required, bool defaultValue) : base(required, defaultValue)
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
    }
}