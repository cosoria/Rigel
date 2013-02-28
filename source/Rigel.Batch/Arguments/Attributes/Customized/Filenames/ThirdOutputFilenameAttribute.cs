namespace Rigel.Batch.Arguments.Attributes.Customized.Filenames
{
    public class ThirdOutputFilenameAttribute : FilenameAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "OutputFilename3";
        private const string HELP_TEXT = "The third output file name.";
        private const string INVALID_VALUE = "'{0}' is not a valid third output file name.";
        private const string MISSING_TEXT = "The third output file '{0}' does not exist.";

        #endregion

        #region Constructors

        public ThirdOutputFilenameAttribute() : base(false)
        {
        }

        public ThirdOutputFilenameAttribute(bool required) : base(required)
        {
        }

        public ThirdOutputFilenameAttribute(bool required, string defaultValue) : base(required, defaultValue)
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