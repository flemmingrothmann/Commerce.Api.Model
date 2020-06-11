using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CommerceClient.Api.Model
{
    public class ContextResponseBody
    {
        public DateTime? PriceCalculationDate { get; set; }
        public string PriceListId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public InventoryCheck InventoryCheck { get; internal set; }
        public bool IsLive { get; set; }
        public CustomerResponse Customer { get; set; }
        public AuthenticationResponse Authentication { get; set; }

        public Language Language { get; set; }
        public Country Country { get; set; }
        public Currency Currency { get; set; }
        public Location Location { get; set; }
        public Api.Model.DataItemsResponseBody<Setting> Settings { get; set; }
#pragma warning disable CA2227 // Collection properties should be read only
        public List<ResourceLink> Links { get; set; }
#pragma warning restore CA2227 // Collection properties should be read only

    }
}
