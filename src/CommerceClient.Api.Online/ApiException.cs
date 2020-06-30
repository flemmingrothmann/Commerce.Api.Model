// Flemming Rothmann

// Flemming Rothmann

using System;
using System.Net;
using System.Runtime.Serialization;
using CommerceClient.Api.Model;

namespace CommerceClient.Api.Online
{
    /// <summary>
    /// The base exception in case the api fails in a controlled way.
    /// </summary>
    [Serializable]
    public class ApiException : Exception
    {
        /// <summary>
        /// Gets any error response retruned by the server. May be null.
        /// </summary>
        public ErrorResponseBase ErrorResponse { get; protected set; }

        /// <summary>
        /// Gets the http response code causing the exception.
        /// </summary>
        public HttpStatusCode ResponseStatusCode { get; set; }

        public ApiException() : base() { }

        public ApiException(HttpStatusCode responseStatusCode, ErrorResponseBase errorResponse): base(errorResponse?.Error?.Message) 
        {
            ErrorResponse = errorResponse;
            ResponseStatusCode = responseStatusCode;
        }

        public ApiException(string message) : base(message) { }

        public ApiException(
            HttpStatusCode responseStatusCode,
            ErrorResponseBase errorResponse,
            string message
        ) : base(message)
        {
            ErrorResponse = errorResponse;
            ResponseStatusCode = responseStatusCode;
        }

        public ApiException(string message, Exception innerException) : base(
            message,
            innerException
        ) { }

        public ApiException(
            HttpStatusCode responseStatusCode,
            ErrorResponseBase errorResponse,
            string message,
            Exception innerException
        ) : base(
            message,
            innerException
        )
        {
            ErrorResponse = errorResponse;
            ResponseStatusCode = responseStatusCode;
        }


        protected ApiException(SerializationInfo info, StreamingContext context) : base(
            info,
            context
        ) { }
    }
}