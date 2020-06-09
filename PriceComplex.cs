namespace Commerce.Api.Model
{
    public class PriceComplex
    {
        public SimpleQuantifiedMeasureResponse Amount { get; set; }
        public Price BeforePrice { get; set; }
        public Price RecommendedPrice { get; set; }
        public Price SalesPrice { get; set; }
        public Price TotalSalesPrice { get; set; }
        public string Description { get; set; }
        public string DiscountLabel { get; set; }
        public string SalesPriceLabel { get; set; }
    }
}