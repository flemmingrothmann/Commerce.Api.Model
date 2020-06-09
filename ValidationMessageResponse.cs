namespace Commerce.Api.Model
{
    public class ValidationMessageResponse
    {
        /// <summary>
        /// The severity of the message. 
        /// </summary>

        public string Severity { get; set; }


        /// <summary>
        /// Localized message.
        /// </summary>
        public string Message { get; set; }


        /// <summary>
        /// The result code helps you identify what kind of issue the message is about.
        /// </summary>
        public string ResultCode { get; set; }

        /// <summary>
        /// An invariant text string containing identification of the error, 
        /// i.e. a never-changing non-localized text code usable for programmatic handling of the message.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Literal reference to what item this message relates to.
        /// Together with the reference property, this enables you to locate exactly what item was
        /// the source for this message.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Together with kind, this identifies exactly what item caused the message.
        /// </summary>
        public string Reference { get; set; }
    }
}