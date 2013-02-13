using System;

namespace Rigel.Core
{
    public static class Ensure
    {
        public static void NotNull<TValue>(TValue value) where TValue:class 
        {
            if (value == null)
            {
                throw Errors.ArgumentNull(typeof(TValue));
            }
        }

        public static void NotNull<TValue>(TValue value, string fieldName) where TValue : class
        {
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException("fieldName");
            if (value == null)
            {
                throw Errors.ArgumentNull(typeof(TValue), fieldName);
            }
        }

        public static void NotNullOrEmpty(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName)) throw new ArgumentNullException("fieldName");
            if (string.IsNullOrEmpty(value))
            {
                throw Errors.NullOrEmptyString(fieldName);
            }
        }
    }
}