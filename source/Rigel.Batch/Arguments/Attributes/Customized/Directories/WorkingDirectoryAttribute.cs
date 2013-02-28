namespace Rigel.Batch.Arguments.Attributes.Customized.Directories
{
    public class WorkingDirectoryAttribute : DirectoryAttribute
    {
        #region Fields/Constants

        public const string CONFIG_KEY = "WorkingDirectory";
        private const string HELP_TEXT = "The file name of the working directory.";
        private const string INVALID_VALUE = "'{0}' is not a valid working directory.";

        #endregion

        #region Constructors

        public WorkingDirectoryAttribute() : base(true, true)
        {
        }

        public WorkingDirectoryAttribute(bool required) : base(true, required)
        {
        }

        public WorkingDirectoryAttribute(bool mustExist, bool required) : base(mustExist, required)
        {
        }

        public WorkingDirectoryAttribute(bool mustExist, bool required, bool create) : base(mustExist, required, create)
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