using System;

namespace Rigel.Batch.Arguments.Attributes.Customized.Filenames
{
    public class InputFilenameAttribute : FilenameAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "InputFilename";
        private const string HELP_TEXT = "The input file name.";
        private const string INVALID_VALUE = "'{0}' is not a valid input file name.";
        private const string MISSING_TEXT = "The input file '{0}' does not exist.";

        #endregion

        #region Constructors

        public InputFilenameAttribute()
        {
        }

        public InputFilenameAttribute(Type folderArgumentType) : base(folderArgumentType)
        {
        }

        public InputFilenameAttribute(bool required) : base(required)
        {
        }

        public InputFilenameAttribute(bool required, bool mustExist) : base(required, mustExist)
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