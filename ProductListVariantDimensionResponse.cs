using System.Collections.Generic;

namespace Commerce.Api.Model
{
    public class ProductListVariantDimensionResponse
    {
        public string Name { get; set; }

        public List<VariantDimensionValue> Values { get; set; }

        public int Index { get; set; }
    }
}