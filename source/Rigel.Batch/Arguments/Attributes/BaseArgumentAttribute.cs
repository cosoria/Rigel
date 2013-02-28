using System;

namespace Rigel.Batch.Arguments.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public abstract class BaseArgumentAttribute : Attribute
    {
        #region Fields

        protected bool _required = false;
        protected bool _switchType = false;
        protected Type _valueType;

        #endregion

        #region Constructors

        protected BaseArgumentAttribute()
        {
        }

        protected BaseArgumentAttribute(bool required)
        {
            _required = required;
        }

        #endregion

        #region Abstract methods

        /// <summary>
        /// Validates and binds the value.  Returns an error message if it is invalid.
        /// </summary>
        /// <param name="value">The value to validate and bind.</param>
        /// <returns>An empty string if the value is valid, the error message otherwise.</returns>
        public abstract string ValidateAndBind(string value);

        #endregion

        #region Properties

        public abstract string HelpText { get; }

        public abstract string InvalidValueText { get; }

        public abstract string ConfigurationKey { get; }

        public bool Required
        {
            get { return _required; }
            set { _required = value; }
        }

        public bool SwitchType
        {
            get { return _switchType; }
            set { _switchType = value; }
        }

        public Type ValueType
        {
            get { return _valueType; }
            set { _valueType = value; }
        }

        public abstract object Value { get; }

        #endregion
    }
}