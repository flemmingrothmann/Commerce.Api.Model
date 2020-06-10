using Newtonsoft.Json;

namespace CommerceClient.Api.Model
{
    /// <summary>
    /// A constraint, that limits how the item in this particular unit can be sold.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SalesUnitConstraintResponse
    {
        public string ExtSalesUnitConstraintId { get; set; }

        /// <summary>
        /// Indicates least common multiple in which that this item can be bought. Quantity bought must be a multiple of this value.
        /// F.inst if your unit is kilo, 1 indicates you buy in chunks of kilos, 0.5 indicates you buy in chunks of half-kilos (note: scale would then be 1 to allow for a decimal)
        /// </summary>
        public decimal? SmallestCount { get; set; }

        /// <summary>
        /// Indicates the minimum number of units clients are required to buy.
        /// </summary>
        public decimal? MinimumCount { get; set; }

        public decimal? MaximumCount { get; set; }

        /// <summary>
        /// Indicates how many decimal places should be shown and accepted for the related unit. this would typically be 1 (one) if buying in chunks of whole units.
        /// </summary>
        public int? Scale { get; set; }
    }
}