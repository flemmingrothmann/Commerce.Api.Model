using System.Collections.Generic;
using Newtonsoft.Json;

namespace Commerce.Api.Model
{
    public class DataProductListResponseBody<T> : DataItemsResponseBody<T> where T : new()
    {
        [JsonProperty(Order = 90)] public List<ProductListVariantDimensionResponse> VariantDimensions { get; set; }

        [JsonProperty(Order = 91)] public List<FilterFieldResponse> FilterFields { get; set; }

        [JsonProperty(Order = 92)] public List<ProductListProductMenuResponse> ProductMenus { get; set; }

        [JsonProperty(Order = 93)] public List<ProductListArticleResponse> Articles { get; set; }

        [JsonProperty(Order = 93)] public ProductListMetaResponse MetaData { get; set; }

        /// <summary>
        /// List all unit of measures referenced by this list.
        /// </summary>
        [JsonProperty(Order = 93)]
        public List<UnitOfMeasureResponse> UnitOfMeasures { get; set; }
    }
}