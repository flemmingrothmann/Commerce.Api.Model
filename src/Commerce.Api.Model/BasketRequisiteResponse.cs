using System.Collections.Generic;

namespace Commerce.Api.Model
{
    public class BasketRequisiteResponse
    {
        public string Action { get; set; }
        public bool IsCompleted { get; set; }
        public List<UniqueReferenceResponse> References { get; set; }
        public List<BasketActionStatus> Requirements { get; set; }
    }
}