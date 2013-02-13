using System;

namespace Rigel.Core
{
    public static class Errors
    {
        public static Exception ArgumentNull(Type type)
        {
            return new ArgumentNullException(string.Format("Argument value of type '{0}' can not be null.", type.Name));
        }

        public static Exception ArgumentNull(Type type, string fieldName)
        {
            var message = string.Format("Value '{1}' of type '{0}' can not be null.", type.Name, fieldName);
            return new ArgumentNullException(fieldName, message);
        }
       
        public static Exception NullOrEmptyString(string fieldName)
        {
            return new ArgumentNullException(fieldName, @"String value can not be null or empty");
        }
    }
}