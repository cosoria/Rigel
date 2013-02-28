namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class StringAttribute : BaseArgumentAttribute
    {
        #region Fields

        protected string _value = null;

        #endregion

        #region Constructors

        protected StringAttribute() : this(false)
        {
        }

        protected StringAttribute(bool required) : base(required)
        {
            _valueType = typeof(string);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Validate the value.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <returns>An empty string if the value is valid, the error message otherwise.</returns>
        public override string ValidateAndBind(string value)
        {
            bool allGood = true;

            if(((string.IsNullOrEmpty(value)) && (_required)))
            {
                allGood = false;
            }
            else
            {
                _value = value;
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