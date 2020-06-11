using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CommerceClient.Api.Model
{
    public class Context
    {
        public DateTime? PriceCalculationDate { get; set; }
        public string PriceListId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public InventoryCheck InventoryCheck { get; internal set; }

        public bool IsLive { get; set; }
        public Customer Customer { get; set; }
        public AuthenticationResponse Authentication { get; set; }

        public Language Language { get; set; }
        public Country Country { get; set; }
        public Currency Currency { get; set; }
        public Location Location { get; set; }
        public DataItemsResponseBody<Setting> Settings { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}