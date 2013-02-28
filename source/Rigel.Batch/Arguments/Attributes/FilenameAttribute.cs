using System;
using System.IO;

namespace Rigel.Batch.Arguments.Attributes
{
    public abstract class FilenameAttribute : BaseArgumentAttribute
    {
        #region Fields

        protected string _defaultValue = null;
        protected string _folder = null;
        protected bool _mustExist = false;
        protected string _value = null;
        protected Type _folderArgumentType;

        #endregion

        #region Constructors

        protected FilenameAttribute() : this(false)
        {
        }

        protected FilenameAttribute(Type folderArgumentType) : this(false)
        {
            _folderArgumentType = folderArgumentType;
        }

        protected FilenameAttribute(bool required) : base(required)
        {
            _valueType = typeof(string);
        }

        protected FilenameAttribute(bool required, string defaultValue) : base(required)
        {
            _valueType = typeof(string);
            _defaultValue = defaultValue;
        }

        protected FilenameAttribute(bool required, bool mustExist) : base(required)
        {
            _valueType = typeof(string);
            _mustExist = mustExist;
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

            if(((string.IsNullOrEmpty(value)) && (_required)) || ((!string.IsNullOrEmpty(value)) && (value.IndexOfAny(Path.GetInvalidPathChars()) > -1)))
            {
                if(!string.IsNullOrEmpty(_defaultValue))
                {
                    _value = _defaultValue;
                }
                else
                {
                    allGood = false;
                }
            }
            else
            {
                if(_folder != null && value != null)
                {
                    _value = Path.Combine(_folder, value);
                }
                else
                {
                    _value = value;
                }

                if(_mustExist && !File.Exists(_value) && ((!string.IsNullOrEmpty(_folder)) && (!File.Exists(Path.Combine(_folder, _value)))))
                {
                    return string.Format(MissingFileText, _value);
                }
            }

            return allGood ? null : string.Format(InvalidValueText, value);
        }

        #endregion

        public override object Value
        {
            get { return _value; }
        }

        public abstract string MissingFileText { get; }

        public string Folder
        {
            get { return _folder; }
            set { _folder = value; }
        }

        public Type FolderArgumentType
        {
            get
            {
                return _folderArgumentType;
            }
        }
    }
}