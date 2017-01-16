using System;
using System.Net;

namespace WoodenMoose.AspNetCore.Exceptions
{
    /// <summary>
    /// The exception that is thrown when ASP.NET should reply to a request with a specific HTTP code.
    /// </summary>
    public class HttpStatusCodeException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpStatusCodeException"/> class
        /// </summary>
        /// <param name="statusCode">The HTTP code to reply</param>
        /// <param name="message">The message to include in the response body</param>
        public HttpStatusCodeException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        /// <summary>
        /// Gets the HTTP code associated to this exception
        /// </summary>
        public HttpStatusCode StatusCode { get; }
    }
}
