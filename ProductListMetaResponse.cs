namespace Commerce.Api.Model
{
    public class ProductListMetaResponse
    {
        public bool ShowProductId { get; set; }
        public bool ShowProductEan { get; set; }
        public bool ShowProductManufacturerSku { get; set; }
        public bool ShowExtProductId { get; set; }
        public bool ShowAltExtProductId { get; set; }
        public bool EnableAddToBasket { get; set; }
    }
}