using System.Net;

namespace ResponseWrapperLib.Exceptions
{
    /// <summary>
    /// Represents a custom exception used specifically for validation
    /// and user-facing business rule failures.
    /// 
    /// Unlike system exceptions, this class is designed to carry structured,
    /// client-friendly error information that can be translated directly
    /// into an HTTP response.
    /// </summary>
    public class CustomValidationException : Exception
    {
        /// <summary>
        /// A collection of detailed validation or business rule errors.
        /// These are typically field-level or rule-specific messages
        /// intended for logging or returning to the client.
        /// </summary>
        public List<string> ErrorMessages { get; set; }

        /// <summary>
        /// A high-level, user-friendly error message summarizing the failure.
        /// This message is safe to show to end users and should not expose
        /// internal system details.
        /// </summary>
        public string FriendlyErrorMessage { get; set; }

        /// <summary>
        /// The HTTP status code that should be returned when this exception
        /// is converted into an API response.
        /// Defaults to 400 (BadRequest) for validation failures.
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Initializes a new instance of the CustomValidationException.
        /// </summary>
        /// <param name="friendlyErrorMessage">
        /// A user-friendly summary of the validation failure.
        /// </param>
        /// <param name="errorMessages">
        /// Optional collection of detailed validation or business rule errors.
        /// </param>
        /// <param name="statusCode">
        /// The HTTP status code associated with this exception.
        /// Defaults to BadRequest (400).
        /// </param>
        public CustomValidationException(
            string friendlyErrorMessage,
            List<string> errorMessages = default,
            HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            FriendlyErrorMessage = friendlyErrorMessage;
            ErrorMessages = errorMessages;
            StatusCode = statusCode;
        }
    }
}
