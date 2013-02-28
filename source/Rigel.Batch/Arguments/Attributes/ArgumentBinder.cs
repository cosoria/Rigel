using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Rigel.Batch.Arguments.Attributes.Customized.Directories;
using Rigel.Batch.Common;

namespace Rigel.Batch.Arguments.Attributes
{
    public class ArgumentBinder
    {
        private static IEnumerable<MemberInfo> GetFieldsAndProperties(Type type)
        {
            foreach (var propertyInfo in type.GetProperties())
            {
                yield return propertyInfo;
            }
            foreach (var fieldInfo in type.GetFields())
            {
                yield return fieldInfo;
            }
        }

        public static List<string> BindArguments(IDictionary<Type, string> args, IBatchApplication application)
        {
            var errors = new List<string>();

            if ((ReturnCode.Instance.HasFailed()) && (application.BatchArguments == null))
            {
                return null;
            }

            foreach (var memberInfo in GetFieldsAndProperties(application.BatchArguments.GetType()))
            {
                BaseArgumentAttribute argumentAttribute;

                if (GetSingleAttribute(memberInfo, out argumentAttribute) == false)
                {
                    continue;
                }

                var argumentType = argumentAttribute.GetType();

                if (args.ContainsKey(argumentType))
                {
                    if (argumentAttribute is FilenameAttribute)
                    {
                        ((FilenameAttribute)argumentAttribute).Folder = ResolveFolder((FilenameAttribute)argumentAttribute, args, application);
                    }

                    var error = argumentAttribute.ValidateAndBind(args[argumentType]);

                    if (error != null)
                    {
                        errors.Add(error);
                    }
                    else
                    {
                        MemberInfoAdapter.Create(memberInfo).SetValue(application.BatchArguments, argumentAttribute.Value);
                    }
                }
                else
                {
                    var configurationError = LoadFromConfiguation(argumentAttribute, application, memberInfo, args);

                    if (!string.IsNullOrEmpty(configurationError))
                    {
                        errors.Add(configurationError);
                    }
                }
            }

            return errors;
        }

        private static string LoadFromConfiguation(BaseArgumentAttribute attribute,
                                                   IBatchApplication application,
                                                   MemberInfo memberInfo,
                                                   IDictionary<Type, string> args)
        {
            string configurationValue;

            if (attribute is WorkingDirectoryAttribute)
            {
                configurationValue = Configuration.GetWorkingDirectory(string.Format("{0}_{1}", application.BatchName, attribute.ConfigurationKey));

            }
            else
            {
                configurationValue = Configuration.GetValue(string.Format("{0}_{1}", application.BatchName, attribute.ConfigurationKey));
            }

            if (attribute is FilenameAttribute)
            {
                ((FilenameAttribute)attribute).Folder = ResolveFolder((FilenameAttribute)attribute, args, application);
            }

            var errorMessage = attribute.ValidateAndBind(configurationValue);

            if (string.IsNullOrEmpty(errorMessage))
            {
                MemberInfoAdapter.Create(memberInfo).SetValue(application.BatchArguments, attribute.Value);
            }

            return errorMessage;
        }

        private static bool GetSingleAttribute<T>(MemberInfo memberInfo, out T match) where T : class
        {
            T[] attributes = (T[])memberInfo.GetCustomAttributes(typeof(T), true);

            switch (attributes.Length)
            {
                case 0:
                    match = null;
                    return false;
                case 1:
                    match = attributes[0];
                    return true;
                default:
                    throw new Exception(String.Format("Member '{0}' has multiple {1} attributes or descendants", memberInfo.Name, typeof(T).Name));
            }
        }

        /// <summary>
        /// Combine with working folder and/or input folder
        /// </summary>
        private static string ResolveFolder(FilenameAttribute argument, IDictionary<Type, string> args, IBatchApplication application)
        {
            if (argument.FolderArgumentType != null)
            {
                var folderArgMemberInfo = GetPropertyOrFieldByAttributeType(application, argument.FolderArgumentType);
                if (folderArgMemberInfo != null)
                {
                    string folder = (string)MemberInfoAdapter.Create(folderArgMemberInfo).GetValue(application.BatchArguments);
                    if (!string.IsNullOrEmpty(folder))
                    {
                        return folder;
                    }
                }
            }

            string workingFolder = args.ContainsKey(typeof(WorkingDirectoryAttribute))
                                       ? args[typeof(WorkingDirectoryAttribute)]
                                       : Configuration.GetWorkingDirectory(application.BatchName + "_" + WorkingDirectoryAttribute.CONFIG_KEY);
            string inputFolder = args.ContainsKey(typeof(InputDirectoryAttribute))
                                     ? args[typeof(InputDirectoryAttribute)]
                                     : Configuration.GetValue(application.BatchName + "_" + InputDirectoryAttribute.CONFIG_KEY);

            if (string.IsNullOrEmpty(inputFolder) == false)
            {
                return Path.Combine(workingFolder, inputFolder);
            }

            return workingFolder;
        }

        private static MemberInfo GetPropertyOrFieldByAttributeType(IBatchApplication application, Type attributeType)
        {
            MemberInfo returnValue = null;
            PropertyInfo[] properties = application.BatchArguments.GetType().GetProperties();
            if (properties != null)
            {
                foreach (PropertyInfo property in properties)
                {
                    object[] attributes = property.GetCustomAttributes(attributeType, true);
                    if (attributes != null && attributes.Length == 1)
                    {
                        returnValue = property;
                        break;
                    }
                }
            }
            if (returnValue == null)
            {
                FieldInfo[] fields = application.BatchArguments.GetType().GetFields();
                if (fields != null)
                {
                    foreach (FieldInfo field in fields)
                    {
                        object[] attributes = field.GetCustomAttributes(attributeType, true);
                        if (attributes != null && attributes.Length == 1)
                        {
                            returnValue = field;
                            break;
                        }
                    }
                }
            }
            return returnValue;
        }
    }
}