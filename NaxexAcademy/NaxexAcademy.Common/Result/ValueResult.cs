using System;

namespace NaxexAcademy.Common.Result
{
    /// <summary>
    /// Indicates if an operation that returns value was successful or not.
    /// </summary>
    public sealed class ValueResult<T> : Result
    {
        private readonly T _value;

        /// <summary>
        /// Gets the value of the result instance. If the Result is
        /// failure, an <see cref="System.InvalidOperationException"/> is thrown
        /// </summary>
        public T Value
        {
            get
            {
                if (this.IsFailure)
                    throw new InvalidOperationException("");

                return _value;
            }
        }

        public ValueResult(bool isSuccess, string error, T value) 
            : base(isSuccess, error)
        {
            _value = value;
        }

        public static ValueResult<T>Ok(T value) =>
            new ValueResult<T>(true, null, value);

        public new static ValueResult<T> Fail(string error) =>
            new ValueResult<T>(false, error, default(T));
    }
}