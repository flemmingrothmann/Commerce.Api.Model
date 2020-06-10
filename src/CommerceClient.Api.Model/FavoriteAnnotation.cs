using System.Collections.Generic;

namespace CommerceClient.Api.Model
{
    public class FavoriteAnnotation
    {
        public int ItemId { get; set; }
        public decimal? SuggestedQuantity { get; set; }
        public int SortOrder { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}