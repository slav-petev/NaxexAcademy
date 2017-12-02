using System;

namespace NaxexAcademy.Common
{
    /// <summary>
    /// Indicates if an operation was successful or not.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Gets a value indicating if the Result has succeeded
        /// </summary>
        public bool IsSuccess { get; }

        /// <summary>
        /// Gets a value indicating if the Result has failed
        /// </summary>
        public bool IsFailure => !IsSuccess;

        /// <summary>
        /// Gets the error message in a Result
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Creates a new instance of the Result class
        /// with the given success status and error
        /// </summary>
        /// <param name="isSuccess">The result success status</param>
        /// <param name="error">The result error</param>
        public Result(bool isSuccess, string error)
        {
            if (isSuccess && !string.IsNullOrWhiteSpace(error))
                throw new ArgumentException("", nameof(error));
            if (!isSuccess && string.IsNullOrWhiteSpace(error))
                throw new ArgumentException("", nameof(error));

            this.IsSuccess = isSuccess;
            this.Error = error;
        }
        
        /// <summary>
        /// Creates a result indicating success
        /// </summary>
        /// <returns>
        /// A result with success status and no error message
        /// </returns>
        public static Result Ok() =>
            new Result(true, null);

        /// <summary>
        /// Creates a result indicating failure
        /// </summary>
        /// <param name="error">The reason why the operation failed</param>
        /// <returns>A result with failed status and an error</returns>
        public static Result Fail(string error) => 
            new Result(false, error);
    }

    /// <summary>
    /// Indicates if an operation that returns value was successful or not.
    /// </summary>
    public sealed class Result<T> : Result
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

        public Result(bool isSuccess, string error, T value) 
            : base(isSuccess, error)
        {
            _value = value;
        }

        public static Result<T>Ok(T value) =>
            new Result<T>(true, null, value);

        public new static Result<T> Fail(string error) =>
            new Result<T>(false, error, default(T));
    }
}