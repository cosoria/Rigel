namespace Rigel.Batch.Arguments.Attributes.Customized.Directories
{
    public class InputDirectoryAttribute : DirectoryAttribute
    {
        #region Fields/Constants

        public const string CONFIG_KEY = "InputFolder";
        private const string HELP_TEXT = "The file name of the input folder.";
        private const string INVALID_VALUE = "'{0}' is not a valid input folder.";

        #endregion

        #region Constructors

        public InputDirectoryAttribute() : base(true, true)
        {
        }

        public InputDirectoryAttribute(bool required) : base(true, required)
        {
        }

        public InputDirectoryAttribute(bool mustExist, bool required) : base(mustExist, required)
        {
        }

        public InputDirectoryAttribute(bool mustExist, bool required, bool create) : base(mustExist, required, create)
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