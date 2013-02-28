using System;
using System.Globalization;
using Rigel.Batch.Common;

namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class DateAttribute : BaseArgumentAttribute
    {
        #region Fields

        protected string _dateTimeFormat = BatchConstants.DATE_FORMAT;
        protected DateTime? _defaultValue;
        protected DateTime? _maxValue;
        protected DateTime? _minValue;
        protected DateTime? _value;

        #endregion

        #region Constructors

        protected DateAttribute() : this(false)
        {
        }

        protected DateAttribute(string dateTimeFormat) : this(false)
        {
            _dateTimeFormat = dateTimeFormat;
        }

        protected DateAttribute(bool required) : this(null, null, required)
        {
        }

        protected DateAttribute(bool required, bool defaultToNow)
            : this(null, null, required)
        {
            if(defaultToNow)
            {
                _defaultValue = DateTime.Now;
            }
        }


        protected DateAttribute(DateTime? defaultValue) : this(null, null, false, defaultValue)
        {
        }

        protected DateAttribute(DateTime? minValue, DateTime? maxValue) : this(minValue, maxValue, false)
        {
        }

        protected DateAttribute(DateTime? minValue, DateTime? maxValue, bool required) : base(required)
        {
            _valueType = typeof(DateTime?);
            _minValue = minValue;
            _maxValue = maxValue;
        }

        public DateAttribute(DateTime? minValue, DateTime? maxValue, bool required, DateTime? defaultValue) : base(required)
        {
            _valueType = typeof(DateTime?);
            _minValue = minValue;
            _maxValue = maxValue;
            _defaultValue = defaultValue;
        }

        #endregion

        public abstract string OutOfRangeMessage { get; }

        public override object Value
        {
            get { return _value; }
        }

        /// <summary>
        /// Validate the value.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>An empty string if the value is valid, the error message otherwise.</returns>
        public override string ValidateAndBind(string value)
        {
            bool allGood = true;
            DateTime? parsed = ParseDateTime(value);

            if(parsed == null)
            {
                if(_defaultValue.HasValue)
                {
                    _value = _defaultValue.Value;

                    return null;
                }
            }

            if((string.IsNullOrEmpty(value) && (_required)) || (parsed == null && _required))
            {
                allGood = false;
            }
            else
            {
                if(_minValue.HasValue && _minValue.Value > parsed)
                {
                    return string.Format(OutOfRangeMessage, parsed, _minValue, _maxValue);
                }

                if(_maxValue.HasValue && _maxValue.Value > parsed)
                {
                    return string.Format(OutOfRangeMessage, parsed, _minValue, _maxValue);
                }

                if(parsed != null)
                {
                    _value = parsed;
                }
            }

            return allGood ? null : string.Format(InvalidValueText, value);
        }

        protected virtual DateTime? ParseDateTime(string value)
        {
            DateTime parsed;

            if(string.IsNullOrEmpty(value))
            {
                return null;
            }
            else if(DateTime.TryParse(value, out parsed))
            {
                return parsed;
            }
            else if(!string.IsNullOrEmpty(_dateTimeFormat))
            {
                return DateTime.ParseExact(value, _dateTimeFormat, CultureInfo.InvariantCulture);
            }

            return null;
        }
    }
}