using System;
using System.IO;

namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class DirectoryAttribute : BaseArgumentAttribute
    {
        #region Fields

        protected bool _create = false;
        protected bool _mustExist = false;
        protected string _value = null;

        #endregion

        #region Constructors

        protected DirectoryAttribute() : this(false)
        {
        }

        protected DirectoryAttribute(bool required) : this(false, required)
        {
        }

        protected DirectoryAttribute(bool mustExist, bool required) : this(mustExist, required, false)
        {
        }

        protected DirectoryAttribute(bool mustExist, bool required, bool create) : base(required)
        {
            _valueType = typeof(string);
            _mustExist = mustExist;
            _create = create;
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

            if(((string.IsNullOrEmpty(value)) && (_required)) || ((value != null) && (value.IndexOfAny(Path.GetInvalidPathChars()) > -1)) ||
               (_mustExist && !Exists(value)))
            {
                if(_create)
                {
                    try
                    {
                        Directory.CreateDirectory(value);
                        _value = value;
                    }
                    catch(Exception exception)
                    {
                        return string.Format(InvalidValueText, exception.Message);
                    }
                }
                else if(_required)
                {
                    allGood = false;
                }
            }
            else
            {
                _value = value;
            }

            return allGood ? null : string.Format(InvalidValueText, value);
        }

        private static bool Exists(string value)
        {
            if(Directory.Exists(value))
            {
                return true;
            }
            else if ((value != null) && (Directory.Exists(value)))
            {
                return true;
            }

            return false;
        }

        #endregion

        public override object Value
        {
            get { return _value; }
        }
    }
}