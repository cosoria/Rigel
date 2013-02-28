using System.Collections.Generic;

namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class StringListAttribute : BaseArgumentAttribute
    {
        #region Fields

        protected char _seperator = ',';
        protected List<string> _value = new List<string>();

        #endregion

        #region Constructors

        public StringListAttribute() : this(false)
        {
        }

        public StringListAttribute(bool required) : base(required)
        {
            _valueType = typeof(List<string>);
        }

        public StringListAttribute(char seperator) : this(seperator, false)
        {
        }

        public StringListAttribute(char seperator, bool required) : base(required)
        {
            _valueType = typeof(List<string>);
            _seperator = seperator;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validate the value, and return an error message if it is invalid.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>An empty string if the value is valid, the error message otherwise.</returns>
        public override string ValidateAndBind(string value)
        {
            bool allGood = true;

            if(!string.IsNullOrEmpty(value))
            {
                string[] values = value.Split(_seperator);

                foreach(string split in values)
                {
                    _value.Add(split);
                }
            }
            else if(_required)
            {
                allGood = false;
            }

            if(!allGood)
            {
                _value.Clear();
            }

            return allGood ? null : string.Format(InvalidValueText, value);
        }

        #endregion

        public override object Value
        {
            get { return _value; }
        }
    }
}