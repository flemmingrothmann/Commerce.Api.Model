using System;
using CommerceClient.Api.Model.JsonConverters;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CommerceClient.Api.Model.RequestModels
{
    public class BasketLineRequestBody
    {
        /// <summary>
        /// Gets or sets the id of product/variant/offer. 
        /// Either ItemKey or ItemStringKey is required unless updating or deleting.
        /// </summary>
        [JsonConverter(typeof(ItemKeyConverter))]
        public ItemKey? ItemKey { get; set; }

        /// <summary>
        /// Gets or sets the id of product/variant/offer.
        /// Either ItemKey or ItemStringKey is required unless updating or deleting.
        /// </summary>
        [JsonConverter(typeof(ItemStringKeyConverter))]
        public ItemStringKey? ItemStringKey { get; set; }

        /// <summary>
        /// Line creation option. By default eSeller tries to add to an existing identical item in basket.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public BasketLineCreationOption? CreateOption { get; set; }

        /// <summary>
        /// Gets or sets an id of the current line to be added. 
        /// This id is ONLY used as an arbitrary id with a negative value, allowing you to refer to it when adding (new) child items in the same POST request.
        /// </summary>
        public int? LineId { get; set; }

        /// <summary>
        /// Gets or sets the id of the parent basket line, either it is an existing line (positive number), or a new line to be added in this request (negative number).
        /// </summary>
        public int? ParentLineId { get; set; }

        /// <summary>
        /// Gets or sets quantity of items.
        /// </summary>
        public decimal? Quantity { get; set; }

        private DateTime? _DeliveryDate;

        /// <summary>
        /// Gets or sets a date when this particular item should be delivered. This participates in uniqueness of a basket line.
        /// </summary>
        public DateTime? DeliveryDate
        {
            get => _DeliveryDate;
            set
            {
                DeliveryDateIsSet = true;
                _DeliveryDate = value;
            }
        }

        [JsonIgnore]
        public bool DeliveryDateIsSet { get; set; }


        [JsonIgnore]
        public bool PriceCalculationDateFollowsDeliveryDateIsSet { get; set; }

        private bool? _PriceCalculationDateFollowsDeliveryDate;

        /// <summary>
        /// Gets or sets a value indicating what date to use to calculate prices.
        /// Note: Requires shop to allow setting price calculation date in API. 
        /// </summary>
        public bool? PriceCalculationDateFollowsDeliveryDate
        {
            get => _PriceCalculationDateFollowsDeliveryDate;
            set
            {
                PriceCalculationDateFollowsDeliveryDateIsSet = true;
                _PriceCalculationDateFollowsDeliveryDate = value;
            }
        }

        private string _Tag;

        /// <summary>
        /// Gets or sets a tag to the line. This field is not processed by eSeller, but carried forward to order, free to be use any purpose. 
        /// This participates in uniqueness of a basket line.
        /// </summary>
        public string Tag
        {
            get => _Tag;
            set
            {
                TagIsSet = true;
                _Tag = value;
            }
        }

        [JsonIgnore]
        public bool TagIsSet { get; set; }

        private string _UserCode1;

        /// <summary>
        /// String property for custom usage. This field is not processed by eSeller, but carried forward to order, free to be use any purpose. 
        /// This participates in uniqueness of a basket line.
        /// </summary>
        public string UserCode1
        {
            get => _UserCode1;
            set
            {
                UserCode1IsSet = true;
                _UserCode1 = value;
            }
        }

        private string _UserCode2;

        [JsonIgnore]
        public bool UserCode1IsSet { get; set; }

        /// <summary>
        /// String property for custom usage. This field is not processed by eSeller, but carried forward to order, free to be use any purpose. 
        /// This participates in uniqueness of a basket line.
        /// </summary>
        public string UserCode2
        {
            get => _UserCode2;
            set
            {
                UserCode2IsSet = true;
                _UserCode2 = value;
            }
        }

        private string _UserCode3;

        [JsonIgnore]
        public bool UserCode2IsSet { get; set; }

        /// <summary>
        /// String property for custom usage. This field is not processed by eSeller, but carried forward to order, free to be use any purpose. 
        /// This participates in uniqueness of a basket line.
        /// </summary>
        public string UserCode3
        {
            get => _UserCode3;
            set
            {
                UserCode3IsSet = true;
                _UserCode3 = value;
            }
        }

        [JsonIgnore]
        public bool UserCode3IsSet { get; set; }


        private string _Description1;

        [JsonIgnore]
        public bool Description1IsSet { get; set; }

        /// <summary>
        /// Gets or sets description. Only applicable if item is of type = "text"
        /// </summary>
        public string Description1
        {
            get => _Description1;
            set
            {
                Description1IsSet = true;
                _Description1 = value;
            }
        }

        private string _Description2;

        /// <summary>
        /// Gets or sets description. Only applicable if item is of type = "text"
        /// </summary>
        public string Description2
        {
            get => _Description2;
            set
            {
                Description2IsSet = true;
                _Description2 = value;
            }
        }

        private string _Description3;

        [JsonIgnore]
        public bool Description2IsSet { get; set; }

        /// <summary>
        /// Gets or sets a third description. This field is not processed by eSeller, but carried forward to order, free to be use any purpose. This participates in uniqueness of a basket line.
        /// </summary>
        public string Description3
        {
            get => _Description3;
            set
            {
                Description3IsSet = true;
                _Description3 = value;
            }
        }

        [JsonIgnore]
        public bool Description3IsSet { get; set; }
    }
}