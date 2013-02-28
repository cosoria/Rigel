using System;

namespace Rigel.Batch.Arguments.Attributes.Customized.Date
{
    public class StartDateAttribute : DateAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "StartDate";
        private const string HELP_TEXT = "The start date to use.  The date is in the format 'YYYY-MM-DD'.";
        private const string INVALID_VALUE = "'{0}' is not a valid start date.  Please specify a date in the format 'YYYY-MM-DD' only.";

        #endregion

        #region Constructors

        public StartDateAttribute()
        {
        }

        public StartDateAttribute(bool required) : base(required)
        {
        }

        public StartDateAttribute(DateTime? defaultValue) : base(defaultValue)
        {
        }

        #endregion

        #region Property starts

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