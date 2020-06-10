namespace CommerceClient.Api.Model
{
    public class ApiError
    {
        public int Code { get; set; }

        public string Reason { get; set; }

        public string Message { get; set; }

        public string Id { get; set; }

        public string MoreInfo { get; set; }

        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Refers to what kind of item is subject to the message.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Reference to the item subject to the message.
        /// This is an id, a comma-separated array of ids, or an array of json-alike structure for complex keys (think of itemKey).
        /// </summary>
        public string Reference { get; internal set; }
    }
}