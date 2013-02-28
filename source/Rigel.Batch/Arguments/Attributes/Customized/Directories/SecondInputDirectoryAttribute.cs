namespace Rigel.Batch.Arguments.Attributes.Customized.Directories
{
    /// <summary>
    /// Same as InputDirectory but OutputFile1 doesnt add this value to its path
    /// </summary>
    public class SecondInputDirectoryAttribute : DirectoryAttribute
    {
        #region Fields/Constants

        public const string CONFIG_KEY = "InputDirectory2";
        private const string HELP_TEXT = "The path of the input folder (not added to outputfile1).";
        private const string INVALID_VALUE = "'{0}' is not a valid input folder.";

        #endregion

        #region Constructors

        public SecondInputDirectoryAttribute() : base(true, true)
        {
        }

        public SecondInputDirectoryAttribute(bool required) : base(true, required)
        {
        }

        public SecondInputDirectoryAttribute(bool mustExist, bool required) : base(mustExist, required)
        {
        }

        public SecondInputDirectoryAttribute(bool mustExist, bool required, bool create) : base(mustExist, required, create)
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