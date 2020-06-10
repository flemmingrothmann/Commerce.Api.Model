using Newtonsoft.Json;

namespace CommerceClient.Api.Model
{
    /// <summary>
    /// Shows a specific unit with reference to the unit specification.
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class SimpleUnitOfMeasureResponse
    {
        public int UnitOfMeasureId { get; set; }
        public string Abbreviation { get; set; }
    }
}