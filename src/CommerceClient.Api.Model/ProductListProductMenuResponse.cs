using System.Collections.Generic;

namespace CommerceClient.Api.Model
{
    public class ProductListProductMenuResponse
    {
        public float? Score { get; set; }

#pragma warning disable CA1056 // Uri properties should not be strings
        public string NavigateUrl { get; set; }
#pragma warning restore CA1056 // Uri properties should not be strings

        public string NavigateText { get; set; }

        public string NavigateTarget { get; set; }

        public string ExtMenuItemId { get; set; }

        public string Description { get; set; }

        public string AlternateDescription { get; set; }

        public int UiSortOrder { get; set; }

        public List<ResourceLink> Links { get; set; }
    }
}