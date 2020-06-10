using System;
using System.Collections.Generic;
using CommerceClient.Api.Model.JsonConverters;
using Newtonsoft.Json;

namespace CommerceClient.Api.Model
{
    public class BasketResponse
    {
        /// <summary>
        /// basket Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Guid of basket.
        /// </summary>
        public Guid BasketGuid { get; set; }

        /// <summary>
        /// Date of last modification in UTC
        /// </summary>
        public DateTime DateModified { get; set; }

        /// <summary>
        /// Gets or sets the name of the basket.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the policies applied to the basket in the current context.
        /// </summary>
        [JsonConverter(typeof(FlagConverter))]
        public BasketPolicies Policies { get; set; }

        public Address BillToAddress { get; set; }

        public Address SellToAddress { get; set; }

        public Address ShipToAddress { get; set; }

        public BasketAnnotationResponse Annotation { get; set; }

        /// <summary>
        /// Gets the total amount for this basket.
        /// </summary>
        public Price BasketTotal { get; set; }

        /// <summary>
        /// How many lines in basket
        /// </summary>
        public int lineCount { get; set; }

        /// <summary>
        /// How many items in basket, i.e. a sum of all quantities.
        /// </summary>
        public decimal itemCount { get; set; }

        /// <summary>
        /// Gets the total amount for items in basket. This excludes any fees applicable.
        /// </summary>
        public Price LineTotal { get; set; }

        /// <summary>
        /// Gets a list of shipments applicable to the basket, including fees.
        /// </summary>
        public List<ShipmentResponse> Shipments { get; set; }

        /// <summary>
        /// Gets a list of payments applicable to the basket, including fees.
        /// </summary>
        public List<PaymentResponse> Payments { get; set; }

        public List<ValidationMessageResponse> ValidationMessages { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}