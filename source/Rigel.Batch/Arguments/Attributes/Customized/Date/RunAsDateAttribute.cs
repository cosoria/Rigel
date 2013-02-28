using System;

namespace Rigel.Batch.Arguments.Attributes.Customized.Date
{
    public class RunAsDateAttribute : DateAttribute
    {
        #region Fields/Constants

        private const string CONFIG_KEY = "RunAsDate";
        private const string HELP_TEXT = "The RunAs date to use.  The date is in the format 'YYYY-MM-DD'.";
        private const string INVALID_VALUE = "'{0}' is not a valid RunAs date.  Please specify a date in the format 'YYYY-MM-DD' only.";

        #endregion

        #region Constructors

        public RunAsDateAttribute()
        {
        }

        public RunAsDateAttribute(bool required) : base(required)
        {
        }

        public RunAsDateAttribute(DateTime? defaultValue) : base(defaultValue)
        {
        }

        public RunAsDateAttribute(bool required, bool defaultToNow)
            : base(null, null, required)
        {
            if(defaultToNow)
            {
                _defaultValue = DateTime.Now;
            }
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