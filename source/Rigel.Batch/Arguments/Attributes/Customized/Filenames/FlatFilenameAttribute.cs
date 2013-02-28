namespace Rigel.Batch.Arguments.Attributes.Customized.Filenames
{
    public class FlatFilenameAttribute : FilenameAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "FlatFileDefinitionFilename";
        private const string HELP_TEXT = "The flat file name.";
        private const string INVALID_VALUE = "'{0}' is not a valid flat file name.";
        private const string MISSING_TEXT = "The flat file definition file '{0}' does not exist.";

        #endregion

        #region Constructors

        public FlatFilenameAttribute()
        {
        }

        public FlatFilenameAttribute(bool required) : base(required)
        {
        }

        public FlatFilenameAttribute(bool required, bool mustExist) : base(required, mustExist)
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

        public override string MissingFileText
        {
            get { return MISSING_TEXT; }
        }

        #endregion
    }
}