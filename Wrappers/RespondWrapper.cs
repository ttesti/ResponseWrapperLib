namespace ResponseWrapperLib.Wrappers
{
    /// <summary>
    /// Concrete implementation of IResponseWrapper that represents
    /// the outcome of an operation without returning data.
    /// 
    /// This class centralizes creation of success and failure responses
    /// through factory methods, ensuring consistent response formatting
    /// across the application.
    /// </summary>
    public class ResponseWrapper : IResponseWrapper
    {
        /// <summary>
        /// A list of messages associated with the operation result.
        /// These may contain validation errors, informational messages,
        /// warnings, or system feedback.
        /// Defaults to an empty list to prevent null reference issues.
        /// </summary>
        public List<string> Messages { get; set; } = [];

        /// <summary>
        /// Indicates whether the operation succeeded.
        /// True = operation completed successfully.
        /// False = operation failed.
        /// </summary>
        public bool IsSuccessfull { get; set; }

        #region Fail Synchronously

        /// <summary>
        /// Creates a failed response with no messages.
        /// Useful when failure state alone is sufficient.
        /// </summary>
        public static IResponseWrapper Fail()
        {
            return new ResponseWrapper()
            {
                IsSuccessfull = false
            };
        }

        /// <summary>
        /// Creates a failed response with a single error message.
        /// Commonly used for validation or business rule failures.
        /// </summary>
        public static IResponseWrapper Fail(string message)
        {
            return new ResponseWrapper()
            {
                IsSuccessfull = false,
                Messages = [message]
            };
        }

        /// <summary>
        /// Creates a failed response with multiple messages.
        /// Useful for returning a collection of validation errors.
        /// </summary>
        public static IResponseWrapper Fail(List<string> messages)
        {
            return new ResponseWrapper()
            {
                IsSuccessfull = false,
                Messages = messages
            };
        }

        #endregion

        #region Fail Asynchronously

        /// <summary>
        /// Asynchronous version of Fail().
        /// Wraps a failed response in a completed Task to support async workflows.
        /// </summary>
        public static Task<IResponseWrapper> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        /// <summary>
        /// Asynchronous version of Fail(string).
        /// </summary>
        public static Task<IResponseWrapper> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        /// <summary>
        /// Asynchronous version of Fail(List<string>).
        /// </summary>
        public static Task<IResponseWrapper> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        #endregion

        #region Success Synchronously

        /// <summary>
        /// Creates a successful response with no messages.
        /// Used when an operation completes without needing to return additional context.
        /// </summary>
        public static IResponseWrapper Success()
        {
            return new ResponseWrapper()
            {
                IsSuccessfull = true
            };
        }

        /// <summary>
        /// Creates a successful response with a single informational message.
        /// </summary>
        public static IResponseWrapper Success(string message)
        {
            return new ResponseWrapper()
            {
                IsSuccessfull = true,
                Messages = [message]
            };
        }

        /// <summary>
        /// Creates a successful response with multiple messages.
        /// </summary>
        public static IResponseWrapper Success(List<string> messages)
        {
            return new ResponseWrapper()
            {
                IsSuccessfull = true,
                Messages = messages
            };
        }

        #endregion

        #region Success Asynchronously

        /// <summary>
        /// Asynchronous version of Success().
        /// Returns a completed Task containing a successful response.
        /// </summary>
        public static Task<IResponseWrapper> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        /// <summary>
        /// Asynchronous version of Success(string).
        /// </summary>
        public static Task<IResponseWrapper> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        /// <summary>
        /// Asynchronous version of Success(List<string>).
        /// </summary>
        public static Task<IResponseWrapper> SuccessAsync(List<string> messages)
        {
            return Task.FromResult(Success(messages));
        }

        #endregion
    }

    public class ResponseWrapper<T> : ResponseWrapper, IResponseWrapper<T>
    {
        /// <summary>
        /// The data payload returned by the operation when it succeeds.
        /// This is read-only to ensure that data is produced by the operation,
        /// not modified by the consumer.
        /// </summary>
        /// 

        #region Factory Methods for Failure with Data Asynchronously
        // Depending on design choices, you could also add factory methods
        // for failure cases that include data (e.g., partial results or error details).

        public static IResponseWrapper<T> Fail(T data)
        {
            return new ResponseWrapper<T>()
            {
                IsSuccessfull = false,
                Data = data
            };
        }

        /// <summary>
        /// Creates a failure response containing data and a single message.
        /// </summary>
        public static IResponseWrapper<T> Fail(T data, string message)
        {
            return new ResponseWrapper<T>()
            {
                IsSuccessfull = false,
                Data = data,
                Messages = [message]
            };
        }
        /// <summary>
        /// Creates a failure response containing data and multiple messages.
        /// </summary>
        public static IResponseWrapper<T> Fail(T data, List<string> messages)
        {
            return new ResponseWrapper<T>()
            {
                IsSuccessfull = false,
                Data = data,
                Messages = messages
            };
        }

        #endregion

        public T Data { get; set; }
        #region Factory Methods for Success with Data Synchronously
        /// <summary>
        /// Creates a successful response containing data and no messages.
        /// </summary>
        public static IResponseWrapper<T> Success(T data)
        {
            return new ResponseWrapper<T>()
            {
                IsSuccessfull = true,
                Data = data
            };
        }
        /// <summary>
        /// Creates a successful response containing data and a single message.
        /// </summary>
        public static IResponseWrapper<T> Success(T data, string message)
        {
            return new ResponseWrapper<T>()
            {
                IsSuccessfull = true,
                Data = data,
                Messages = [message]
            };
        }
        /// <summary>
        /// Creates a successful response containing data and multiple messages.
        /// </summary>
        public static IResponseWrapper<T> Success(T data, List<string> messages)
        {
            return new ResponseWrapper<T>()
            {
                IsSuccessfull = true,
                Data = data,
                Messages = messages
            };
        }
        #endregion

    }
}

