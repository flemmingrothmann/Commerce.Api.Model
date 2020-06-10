using System.Collections.Generic;

namespace CommerceClient.Api.Model
{
    public class BasketUserValueResponse
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public bool IsVisibleOnOrder { get; set; }

        public string ContentType { get; set; }

        public string ContentTransferEncoding { get; set; }

        public List<ResourceLink> Links { get; set; }
    }
}