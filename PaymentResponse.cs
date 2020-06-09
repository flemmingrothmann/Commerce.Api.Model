namespace Commerce.Api.Model
{
    public class PaymentResponse : ResourceResponse
    {
        public string ExtPaymentMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Aplicable fee, added to the total value of basket.
        /// </summary>
        public Price Fee { get; set; }

        /// <summary>
        /// Any amount already reserved for payment. Amount due is totalvalue minus sum(AmountReserved)
        /// </summary>
        public Price AmountReserved { get; set; }
    }
}