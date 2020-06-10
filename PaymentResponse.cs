using System.Collections.Generic;

namespace Commerce.Api.Model
{
    public class PaymentResponse
    {
        public string ExtPaymentMethodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        /// <summary>
        /// Applicable fee, added to the total value of basket.
        /// </summary>
        public Price Fee { get; set; }

        /// <summary>
        /// Any amount already reserved for payment. Amount due is total value minus sum(AmountReserved)
        /// </summary>
        public Price AmountReserved { get; set; }

        public List<ResourceLink> Links { get; set; }
    }
}