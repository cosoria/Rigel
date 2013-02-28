using System;

namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class BooleanAttribute : BaseArgumentAttribute
    {
        protected bool? _defaultValue = null;
        protected bool? _value = null;

        protected BooleanAttribute() : base(false)
        {
        }

        protected BooleanAttribute(bool required) : base(required)
        {
        }

        protected BooleanAttribute(bool required, bool defaultValue) : base(required)
        {
            _defaultValue = defaultValue;
        }

        public override object Value
        {
            get { return _value; }
        }

        public bool? DefaultValue
        {
            get { return _defaultValue; }
            set { _defaultValue = value; }
        }

        /// <summary>
        /// Validates and binds the value.  Returns an error message if it is invalid.
        /// </summary>
        /// <param name="value">The value to validate and bind.</param>
        /// <returns>An empty string if the value is valid, the error message otherwise.</returns>
        public override string ValidateAndBind(string value)
        {
            bool allGood = true;
            bool parsed;

            if(((string.IsNullOrEmpty(value)) && (_required)) || ((!Boolean.TryParse(value, out parsed))))
            {
                allGood = false;
            }
            else
            {
                _value = parsed;
            }

            if((!string.IsNullOrEmpty(value)) && (!Boolean.TryParse(value, out parsed)))
            {
                if(value.ToLower() == "y")
                {
                    _value = true;
                    allGood = true;
                }
                else if(value.ToLower() == "n")
                {
                    _value = false;
                    allGood = true;
                }
                else
                {
                    allGood = false;
                }
            }

            if(string.IsNullOrEmpty(value) && (_defaultValue != null) && (_defaultValue.HasValue))
            {
                _value = _defaultValue.Value;
                allGood = true;
            }

            return allGood ? null : string.Format(InvalidValueText, value);
        }
    }
}