using System;
using System.Collections.Generic;

namespace Rigel.Batch.Arguments.Attributes
{
    public class ArgumentParser
    {
        private static readonly IDictionary<string, Type> _argumentTokens = RegisteredArgumentAttributes.FetchRegisteredArgumentTokens();

        public static IDictionary<Type, string> DetermineArgumentTypes(string[] commandLineArguments)
        {
            IDictionary<Type, string> argumentTypes = new Dictionary<Type, string>();

            foreach(string commandLineArgument in commandLineArguments)
            {
                string[] argumentAndValue = commandLineArgument.ToLower().Split(':');

                if(_argumentTokens.ContainsKey(argumentAndValue[0].ToLower()))
                {
                    if(argumentAndValue.Length > 1)
                    {
                        argumentTypes.Add(_argumentTokens[argumentAndValue[0].ToLower()], commandLineArgument.Substring(argumentAndValue[0].Length + 1));
                    }
                    else
                    {
                        argumentTypes.Add(_argumentTokens[argumentAndValue[0].ToLower()], null);
                    }
                }
                else
                {
                    throw new ArgumentException("Unknown argument", commandLineArgument);
                }
            }

            return argumentTypes;
        }
    }
}