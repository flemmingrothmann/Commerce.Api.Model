using System;

namespace CommerceClient.Api.Model
{
    [Serializable]
    public class ErrorResponseBase : ResponseBase
    {
        public Error Error { get; set; }
    }
}