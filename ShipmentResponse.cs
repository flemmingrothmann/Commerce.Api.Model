namespace Commerce.Api.Model
{
    public class ShipmentResponse : ResourceResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Fee { get; set; }
        public bool IsCollectAtStore { get; set; }
    }
}