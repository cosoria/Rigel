using System;

namespace Rigel.Batch.Arguments.Attributes.Customized.Date
{
    public class EndDateAttribute : DateAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "EndDate";
        private const string HELP_TEXT = "The end date to use.  The date is in the format 'YYYY-MM-DD'.";
        private const string INVALID_VALUE = "'{0}' is not a valid end date.  Please specify a date in the format 'YYYY-MM-DD' only.";

        #endregion

        #region Constructors

        public EndDateAttribute()
        {
        }

        public EndDateAttribute(bool required) : base(required)
        {
        }

        public EndDateAttribute(bool required, bool defaultToNow)
            : base(required, defaultToNow)
        {
        }

        public EndDateAttribute(DateTime? defaultValue) : base(defaultValue)
        {
        }

        #endregion

        #region Properties

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

        public override string OutOfRangeMessage
        {
            get { return string.Empty; }
        }

        #endregion
    }
}