using System;
using Commerce.Api.Model.JsonConverters;
using Newtonsoft.Json;

namespace Commerce.Api.Model
{
    public class BasketLineResponse : ResourceResponse
    {
        public int LineId { get; set; }
        public string Tag { get; set; }
        public int? ParentLineId { get; set; }

        /// <summary>
        /// Unique identification of the item. This id is used in most api calls due to its uniqueness.
        /// The identity typically maps to an underlying database table.
        /// </summary>
        [JsonConverter(typeof(ItemKeyConverter))]
        public ItemKey ItemKey { get; set; }

        public string ItemSubType { get; set; }

        public int? InternalItemId2 { get; set; }

        public bool IsLineEditable { get; set; }
        public bool IsLineDeleteable { get; set; }

        /// <summary>
        /// Gets a value indicating if any child lines should be initially collapsed.
        /// </summary>
        public bool IsLineCollapse { get; set; }

        public bool IsAmountVisible { get; set; }
        public bool IsQuantityVisible { get; set; }
        public bool IsAmountInTotals { get; set; }


        /// <summary>
        /// External (as opposed to internal) id of the item. This is the item number recognized in your ERP / warehouse system.
        /// </summary>
        public string ExternalItemId1 { get; set; }

        public string ExternalItemId2 { get; set; }
        public string SecondaryId { get; set; }
        public string EAN { get; set; }

        /// <summary>
        /// In case of integrating with  Point Of Sales system, the identification to that system may be listed here.
        /// </summary>
        public string PosId { get; set; }

        public decimal? Quantity { get; set; }
        public Price LineAmount { get; set; }
        public Price UnitPrice { get; set; }
        public string ItemUrl { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? PriceCalculationDate { get; set; }
        public string UserCode1 { get; set; }
        public string UserCode2 { get; set; }
        public string UserCode3 { get; set; }
    }
}