using Newtonsoft.Json;

namespace CommerceClient.Api.Model
{
    public class BasketFeeResponse
    {
        public enum FeeType
        {
            Shipment,
            Payment
        }

        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public FeeType TypeOfFee { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public Price Fee { get; set; }

        /// <summary>
        /// Indicates if the order will be picked up by customer (true) or to be shipped by a carrier.
        /// </summary>
        public bool IsCollectAtStore { get; set; }
    }
}