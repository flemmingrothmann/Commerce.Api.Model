using System;
using System.Collections.Generic;
using Commerce.Api.Model.JsonConverters;
using Newtonsoft.Json;

namespace Commerce.Api.Model
{
    public class Product<T> where T : new()
    {
        public string ItemVersion { get; set; }
        public string ExtVariantId { get; set; }
        public string ExtItemId { get; set; }

        [JsonConverter(typeof(ItemKeyConverter))]
        public ItemKey ItemKey { get; set; }

        public string Name { get; set; }


        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        public string SeoMetaTagKeywords { get; set; }


        public string SeoHtmlTitle { get; set; }

        public string SeoMetaTagDescription { get; set; }

        /// <summary>
        /// Relative score of this item. Useful for ranking search results.
        /// </summary>
        public double? Score { get; set; }

        public string VariantName { get; set; }
        public List<string> VariantValues { get; set; }
        public bool? HasVariants { get; set; }
        public bool HasSalesPrice { get; set; }
        public bool ShowSalesPrice { get; set; }
        public bool? FrontPageProduct { get; set; }
        public bool? GreatBuy { get; set; }
        public bool? NoveltyProduct { get; set; }
        public bool? Deprecated { get; set; }

        public int? ManufacturerId { get; set; }
        public string Manufacturer { get; set; }
        public string ManufacturerSku { get; set; }
        public bool? HasExpectedDeliveryDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }

        public string Shipments { get; set; }

        /// <summary>
        /// Indicates if this item can be bought.
        /// </summary>
        public bool IsBuyable { get; set; }

        /// <summary>
        /// Indicates if this item can be added to basket.
        /// </summary>
        public bool ShowAddToBasket { get; set; }

        public bool ShowAddToFavorites { get; set; }

        /// <summary>
        /// Indicates if this item is physical and limited in quantity.
        /// Works with shop configurations to control out-of-stock behaviour.
        /// </summary>
        public bool BoundToInventoryCount { get; set; }

        public SimpleQuantifiedMeasureResponse GrossWeight { get; set; }
        public List<SimpleUnitOfMeasureResponse> SalesUnit { get; set; }
        public List<SalesUnitConstraintResponse> SalesUnitConstraints { get; set; }
        public List<PriceComplex> SalesPrices { get; set; }
        public List<ResourceLink> Links { get; set; }
        public List<CustomFieldValue> CustomFields { get; set; }

        public decimal? SuggestedQuantity { get; set; }
        public string Ean { get; set; }

        /// <summary>
        /// Makes variants of product lists. Used for favorite lists.
        /// </summary>
        public T Annotation { get; set; }
    }
}