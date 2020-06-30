using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;
using CommerceClient.Api.Model;

namespace CommerceClient.Api.Online
{
    /// <summary>
    /// This exception is returned when a ResourceNotFound 404 is returned from the api.
    /// The errordata may or may not be populated depending on the response from the api.
    /// </summary>
    [Serializable]
    public class NotFoundException : ApiException
    {
        public NotFoundException() : base() { }
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(HttpStatusCode responseStatusCode, ErrorResponseBase errorResponse) : base(
            responseStatusCode,
            errorResponse
        )
        { }

        public NotFoundException(string message, Exception innerException) : base(
            message,
            innerException
        )
        { }

        public NotFoundException(
            HttpStatusCode responseStatusCode,
            ErrorResponseBase errorResponse,
            string message
        ) : base(
            responseStatusCode,
            errorResponse,
            message
        )
        { }

        public NotFoundException(
            HttpStatusCode responseStatusCode,
            ErrorResponseBase errorResponse,
            string message,
            Exception innerException
        ) : base(
            responseStatusCode,
            errorResponse,
            message,
            innerException
        ) => ErrorResponse = errorResponse;

        protected NotFoundException(SerializationInfo info, StreamingContext context) : base(
            info,
            context
        )
        { }

    }

    /// <summary>
    /// This exception is returned when a ResourceNotFound 404 is returned from the api.
    /// The errordata may or may not be populated depending on the response from the api.
    /// </summary>
    [Serializable]
    public class UnauthorizedException : ApiException
    {
        /// <summary>
        /// Gets any challenges returned by the unauthorized api.
        /// </summary>
        public string Challenge { get; protected set; }
        public IList<string> Reasons { get; } = new List<string>();

        public UnauthorizedException() : base() { }
        public UnauthorizedException(string message) : base(message)
        {
        }

        public UnauthorizedException(string message, Exception innerException) : base(
            message,
            innerException
        )
        { }

        public UnauthorizedException(
            HttpStatusCode responseStatusCode,
            IEnumerable<string> reasons,
            string challenge
        ) : base(
            responseStatusCode,
            null
        )
        {
            Challenge = challenge;
            if (reasons!=null)
                foreach (var reason in reasons)
                {
                    Reasons.Add(reason);
                }
        }

        protected UnauthorizedException(SerializationInfo info, StreamingContext context) : base(
            info,
            context
        )
        { }

    }
}