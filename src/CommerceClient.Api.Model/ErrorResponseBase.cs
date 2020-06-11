using System;

namespace CommerceClient.Api.Model
{
    [Serializable]
    public class ErrorResponseBase : ResponseBase
    {
        public ErrorResponse Error { get; set; }
    }
}