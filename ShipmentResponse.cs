using System.Collections.Generic;

namespace Commerce.Api.Model
{
    public class ShipmentResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Fee { get; set; }
        public bool IsCollectAtStore { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}