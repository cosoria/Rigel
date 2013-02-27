using System;
using System.Linq.Expressions;

namespace Rigel.Core.Reflection
{
    public static class Reflect
    {
        public static string VariableName<T>(Expression<Func<T>> expression)
        {
            if (expression == null)
            {
                return "?";
            }

            var body = expression.Body as MemberExpression;
            if (body == null)
            {
                return "?";
            }

            return body.Member.Name;
        }
    }
}