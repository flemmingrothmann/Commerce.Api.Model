namespace CommerceClient.Api.Model
{
    public class FilterFieldValueResponse
    {
        public string NativeValue { get; set; }
        public string Value { get; set; }

        /// <summary>
        /// How many items within the result has this value.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// How many items within the un-filtered result has this value.
        /// </summary>
        public int GrossCount { get; set; }

        public bool? IsApplied { get; set; }
    }
}