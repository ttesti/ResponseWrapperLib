namespace ResponseWrapperLib.Wrappers
{
    /// <summary>
    /// Non-generic base interface that defines the common structure
    /// of a response wrapper returned from a service, API call, or operation.
    /// </summary>
    public interface IResponseWrapper
    {
        /// <summary>
        /// A collection of informational, warning, or error messages
        /// related to the execution of the operation.
        /// This can be used for validation errors, system messages, etc.
        /// </summary>
        public List<string> Messages { get; set; }

        /// <summary>
        /// Indicates whether the operation completed successfully.
        /// True = success, False = failure.
        /// This allows consumers to quickly check the outcome
        /// without inspecting messages or data.
        /// </summary>
        public bool IsSuccessfull { get; set; }
    }

    /// <summary>
    /// Generic version of the response wrapper that includes
    /// a strongly-typed data payload along with status and messages.
    /// 
    /// The "out T" makes the type parameter covariant, meaning this
    /// interface can be used in output positions (return values) safely.
    /// </summary>
    public interface IResponseWrapper<out T> : IResponseWrapper
    {
        /// <summary>
        /// The data returned by the operation when it succeeds.
        /// Read-only to enforce that data is produced by the operation,
        /// not modified by the consumer.
        /// </summary>
        public T Data { get; }
    }
}
