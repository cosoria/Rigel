using System;

namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class IntegerAttribute : BaseArgumentAttribute
    {
        #region Fields

        protected int? _defaultValue = null;
        protected int? _maxValue = null;
        protected int? _minValue = null;
        protected int? _value = null;

        #endregion

        #region Constructors

        protected IntegerAttribute() : this(false)
        {
        }

        protected IntegerAttribute(bool required) : this(null, null, required)
        {
        }

        protected IntegerAttribute(int? minValue, int? maxValue) : this(minValue, maxValue, false)
        {
        }

        protected IntegerAttribute(int? minValue, int? maxValue, bool required) : base(required)
        {
            _valueType = typeof(int);
            _minValue = minValue;
            _maxValue = maxValue;
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
            int parsed;

            if(!Int32.TryParse(value, out parsed))
            {
                if((_defaultValue != null) && (_defaultValue.HasValue))
                {
                    value = _defaultValue.Value.ToString();
                }
            }
            else
            {
                _value = parsed;
                return null;
            }

            if((string.IsNullOrEmpty(value)) && (_required))
            {
                allGood = false;
            }
            else if((!string.IsNullOrEmpty(value)) && (!Int32.TryParse(value, out parsed)) && (_required))
            {
                allGood = false;
            }
            else
            {
                if(((_minValue != null) && (_minValue.HasValue)) && (_minValue.Value > parsed))
                {
                    return string.Format(OutOfRangeMessage, parsed, _minValue, _maxValue);
                }

                if(((_maxValue != null) && (_maxValue.HasValue)) && (_maxValue.Value > parsed))
                {
                    return string.Format(OutOfRangeMessage, parsed, _minValue, _maxValue);
                }

                if(string.IsNullOrEmpty(value))
                {
                    _value = null;
                }
                else
                {
                    _value = parsed;
                }
            }

            return allGood ? null : string.Format(InvalidValueText, value);
        }
    }
}