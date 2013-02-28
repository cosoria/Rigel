namespace Rigel.Batch.Arguments.Attributes.Customized.Filenames
{
    public class SecondInputFilenameAttribute : FilenameAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "InputFilename2";
        private const string HELP_TEXT = "The second input file name.";
        private const string INVALID_VALUE = "'{0}' is not a valid second input file name.";
        private const string MISSING_TEXT = "The second file '{0}' does not exist.";

        #endregion

        public SecondInputFilenameAttribute(bool required) : base(required)
        {
        }

        public SecondInputFilenameAttribute(bool required, bool mustExist)
            : base(required, mustExist)
        {
        }


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