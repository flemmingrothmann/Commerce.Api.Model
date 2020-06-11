using System;

namespace CommerceClient.Api.Model
{
    [Serializable]
    public class ErrorResponse
    {
        //public ErrorResponseBody() => Errors = new System.Collections.Generic.List<ApiError>();
        public int Code { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Represents any errors encountered during the request.
        /// </summary>
        public System.Collections.Generic.List<ApiError> Errors { get; set; }
    }
}