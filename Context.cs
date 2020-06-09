using System;

namespace Commerce.Api.Model
{
    public class Context : ResourceResponse
    {
        public DateTime? PriceCalculationDate { get; set; }
        public string PriceListId { get; set; }

        public string InventoryCheck { get; internal set; }
        public bool IsLive { get; set; }
        public Customer Customer { get; set; }
        public Authentication Authentication { get; set; }

        public Language Language { get; set; }
        public Country Country { get; set; }
        public Currency Currency { get; set; }
        public Location Location { get; set; }
        public DataItemsResponseBody<Setting> Settings { get; set; }
    }
}