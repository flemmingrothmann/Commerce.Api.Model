using System.Collections.Generic;
using CommerceClient.Api.Model.JsonConverters;
using Newtonsoft.Json;

namespace CommerceClient.Api.Model
{
    public class CustomerResponse
    {
        public int CustomerId { get; set; }

        [JsonConverter(typeof(FlagConverter))]
        public CustomerPolicies Policies { get; set; }

        /// <summary>
        /// The currency that should be considered preferred by customer if any.
        /// </summary>
        public Currency Currency { get; set; }

        public Address BillToAddress { get; set; }

        public Address SellToAddress { get; set; }

#pragma warning disable CA2227 // Collection properties should be read only
        public List<Address> ShipToAddresses { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
        public string ExtCustomerId { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public List<ResourceLink> Links { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only
    }
}