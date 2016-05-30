using System;
using System.Collections.Generic;
using System.Linq;

namespace Rigel.Core
{
    public class Result
    {
        private bool _success;
        private readonly List<string> _errors;

        public bool Succeed { get { return _success; } }
        public bool Failed { get { return !_success; } }
        public string[] Errors { get { return _errors.ToArray(); } }
        
        protected Result(bool sucess) : this(sucess, Enumerable.Empty<string>())
        {
        }

        protected Result(bool sucess, IEnumerable<string> errors)
        {
            _errors = new List<string>();
            _success = sucess;


            if (_success && errors.Any())
            {
                throw new InvalidOperationException("Errors property must be empty if result is set to success");
            }

            if (!_success && !_errors.Any())
            {
                throw new InvalidOperationException("Errors property can not empty when result is set failure");
            }
        }

        public Result CombineWith(Result another)
        {
            if (another == null)
            {
                return this;
            }


            if (another.Failed)
            {
                _errors.AddRange(another._errors);
                _success = false;
            }

            return this;
        }

        public Result CombineWith(IEnumerable<Result> others)
        {
            foreach (var r in others)
            {
                CombineWith(r);
            }

            return this;
        }
    

        public static Result OK()
        {
            return new Result(true, Enumerable.Empty<string>());
        }

        public static Result<T> OK<T>(T value)
        {
            return new Result<T>(value, true, null);
        }

        public static Result Error(IEnumerable<string> errors)
        {
            return new Result(false, errors);
        }

        public static Result Error<T>(IEnumerable<string> errors)
        {
            return new Result<T>(default(T), false, errors);
        }

        public static Result Error(string error)
        {
            return new Result(false, new string[] { error });
        }
        
        public static Result Error<T>(string error)
        {
            return new Result<T>(default(T), false, new string[] { error });
        }

        public static Result Combine(IEnumerable<Result> results)
        {
            var all = OK();

            foreach (var r in results)
            {
                all.CombineWith(r);
            }

            return all;
        }
    }

    public class Result<T> : Result 
    {
        private readonly T _value;

        public T Value { get { return _value; } }

        protected internal Result(T value, bool success, IEnumerable<string> errors)
            : base(success, errors)
        {
            _value = value;
        }
    }
}