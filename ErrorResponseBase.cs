using System;

namespace Commerce.Api.Model
{
    [Serializable]
    public class ErrorResponseBase : ResponseBase
    {
        public Error Error { get; set; }
    }
}