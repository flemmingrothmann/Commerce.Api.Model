using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CommerceClient.Api.Model
{
    public class InputFieldPolicyResponse
    {
        public string FieldName { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public KindOfField Kind { get; set; }

        public string FieldPolicy { get; set; }

        public string Lookup { get; set; }
        public string RegExValidation { get; set; }
        public int? MaxLength { get; set; }
        public decimal? LowerBound { get; set; }
        public decimal? UpperBound { get; set; }
    }
}