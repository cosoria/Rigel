using System;

namespace Rigel.Batch.Arguments.Attributes.Customized.Filenames
{
    public class OutputFilenameAttribute : FilenameAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "OutputFilename";
        private const string HELP_TEXT = "The output file name.";
        private const string INVALID_VALUE = "'{0}' is not a valid output file name.";
        private const string MISSING_TEXT = "The output file '{0}' does not exist.";

        #endregion

        #region Constructors

        public OutputFilenameAttribute() : base(false)
        {
        }

        public OutputFilenameAttribute(Type folderArgumentType) : base(folderArgumentType)
        {
        }

        public OutputFilenameAttribute(bool required) : base(required)
        {
        }

        public OutputFilenameAttribute(bool required, string defaultValue) : base(required, defaultValue)
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