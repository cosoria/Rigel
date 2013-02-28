namespace Rigel.Batch.Arguments.Attributes.Customized.Filenames
{
    public class SecondOutputFilenameAttribute : FilenameAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "OutputFilename2";
        private const string HELP_TEXT = "The second output file name.";
        private const string INVALID_VALUE = "'{0}' is not a valid second output file name.";
        private const string MISSING_TEXT = "The second output file '{0}' does not exist.";

        #endregion

        #region Constructors

        public SecondOutputFilenameAttribute() : base(false)
        {
        }

        public SecondOutputFilenameAttribute(bool required) : base(required)
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