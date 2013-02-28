using System;

namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class DecimalAttribute : BaseArgumentAttribute
    {
        #region Fields

        protected decimal? _defaultValue = null;
        protected decimal? _maxValue = null;
        protected decimal? _minValue = null;
        protected decimal? _value = null;

        #endregion

        #region Constructors

        public DecimalAttribute() : this(false)
        {
        }

        public DecimalAttribute(bool required) : this(null, null, required)
        {
        }

        public DecimalAttribute(decimal? minValue, decimal? maxValue) : this(minValue, maxValue, false)
        {
        }

        public DecimalAttribute(decimal? minValue, decimal? maxValue, bool required) : base(required)
        {
            _valueType = typeof(decimal);
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
            decimal parsed;

            if(!Decimal.TryParse(value, out parsed))
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

            if(((string.IsNullOrEmpty(value)) && (_required)) || ((!Decimal.TryParse(value, out parsed))))
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

                _value = parsed;
            }

            return allGood ? null : string.Format(InvalidValueText, value);
        }
    }
}