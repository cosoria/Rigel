using System;
using System.Reflection;

namespace Rigel.Batch.Arguments.Attributes
{
    /// <summary>
    /// The MemberInfoAdapter provides a unified interface to the 
    /// Reflection.FieldInfo and Reflection.PropertyInfo classes, freeing
    /// Binder, Parser and Attributes from messing implementation details that
    /// they don't care about.
    /// </summary>
    public abstract class MemberInfoAdapter
    {
        public abstract Type Type { get; }
        public abstract string Name { get; }
        public abstract object GetValue(object obj);
        public abstract void SetValue(object obj, object value);

        public static MemberInfoAdapter Create(MemberInfo memberInfo)
        {
            if(memberInfo is PropertyInfo)
            {
                return new PropertyAdpter((PropertyInfo)memberInfo);
            }
            else if(memberInfo is FieldInfo)
            {
                return new FieldAdpter((FieldInfo)memberInfo);
            }
            else
            {
                throw new Exception(String.Format("'{0}' is not a property or field", memberInfo.Name));
            }
        }

        #region Nested type: FieldAdpter

        protected class FieldAdpter : MemberInfoAdapter
        {
            private readonly FieldInfo _fieldInfo;

            public FieldAdpter(FieldInfo fieldInfo)
            {
                if(fieldInfo.IsInitOnly)
                {
                    throw new Exception(String.Format("Cannot write to field '{0}'", fieldInfo.Name));
                }

                _fieldInfo = fieldInfo;
            }

            public override Type Type
            {
                get { return _fieldInfo.FieldType; }
            }

            public override string Name
            {
                get { return _fieldInfo.Name; }
            }

            public override object GetValue(object obj)
            {
                return _fieldInfo.GetValue(obj);
            }

            public override void SetValue(object obj, object value)
            {
                _fieldInfo.SetValue(obj, value);
            }
        }

        #endregion

        #region Nested type: PropertyAdpter

        protected class PropertyAdpter : MemberInfoAdapter
        {
            private readonly PropertyInfo _propertyInfo;

            public PropertyAdpter(PropertyInfo propertyInfo)
            {
                if(!propertyInfo.CanWrite)
                {
                    throw new Exception(String.Format("Cannot write to property '{0}'", propertyInfo.Name));
                }

                if(propertyInfo.GetIndexParameters().Length > 0)
                {
                    throw new Exception(String.Format("Indexed property '{0}' not supported", propertyInfo.Name));
                }

                _propertyInfo = propertyInfo;
            }

            public override Type Type
            {
                get { return _propertyInfo.PropertyType; }
            }

            public override string Name
            {
                get { return _propertyInfo.Name; }
            }

            public override object GetValue(object obj)
            {
                try
                {
                    return _propertyInfo.GetValue(obj, null);
                }
                catch (TargetInvocationException ex)
                {
                    // if property throws exceptions during set (ie, as a 
                    // form of validation, throw their exception instead
                    // of the reflection exception
                    if (ex.InnerException != null)
                    {
                        throw ex.InnerException;
                    }

                    throw;
                }
            }

            public override void SetValue(object obj, object value)
            {
                try
                {
                    _propertyInfo.SetValue(obj, value, null);
                }
                catch(TargetInvocationException ex)
                {
                    // if property throws exceptions during set (ie, as a 
                    // form of validation, throw their exception instead
                    // of the reflection exception
                    if(ex.InnerException != null)
                    {
                        throw ex.InnerException;
                    }

                    throw;
                }
            }
        }

        #endregion
    }
}