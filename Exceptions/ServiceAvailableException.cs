using System.Net;

namespace ResponseWrapperLib.Exceptions
{
    /// <summary>
    /// Represents an exception that occurs when a required service,
    /// dependency, or external system is unavailable.
    /// 
    /// This is typically used for infrastructure or downstream failures
    /// (e.g., database, API, message broker) and maps to HTTP 503.
    /// </summary>
    public class ServiceUnAvailableException : Exception
    {
        /// <summary>
        /// A collection of technical or diagnostic error messages related
        /// to the service failure. These are useful for logging, monitoring,
        /// or debugging, but may not always be suitable for direct display
        /// to end users.
        /// </summary>
        public List<string> ErrorMessages { get; set; }

        /// <summary>
        /// A user-friendly message explaining that the service is currently
        /// unavailable. This should avoid exposing internal implementation
        /// details and is safe for client responses.
        /// </summary>
        public string FriendlyErrorMessage { get; set; }

        /// <summary>
        /// The HTTP status code associated with this failure.
        /// Defaults to 503 (ServiceUnavailable), which indicates that the
        /// server is temporarily unable to handle the request.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the ServiceUnAvailableException.
        /// </summary>
        /// <param name="friendlyErrorMessage">
        /// A user-friendly explanation that the service or dependency is unavailable.
        /// </param>
        /// <param name="errorMessages">
        /// Optional collection of technical or diagnostic error details.
        /// </param>
        /// <param name="statusCode">
        /// The HTTP status code representing the failure.
        /// Defaults to ServiceUnavailable (503).
        /// </param>
        public ServiceUnAvailableException(
            string friendlyErrorMessage,
            List<string> errorMessages = default,
            HttpStatusCode statusCode = HttpStatusCode.ServiceUnavailable)
        {
            FriendlyErrorMessage = friendlyErrorMessage;
            ErrorMessages = errorMessages;
            StatusCode = statusCode;
        }
    }
}
