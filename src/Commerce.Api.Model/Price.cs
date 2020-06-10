namespace Commerce.Api.Model
{
    /// <summary>
    /// A special implementation of IPrice, that targets api usage.
    /// </summary>
    public class Price
    {
        public string CurrencySymbol { get; set; }

        public decimal? VatPercentage { get; set; }

        public decimal VatAmount { get; set; }

        public bool IsPriceIncVat { get; set; }

        public decimal PriceIncVat { get; set; }

        public decimal PriceExVat { get; set; }

        public decimal TagPrice => IsPriceIncVat ? PriceIncVat : PriceExVat;
    }
}