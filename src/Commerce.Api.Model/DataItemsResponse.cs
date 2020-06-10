namespace Commerce.Api.Model
{
    public class DataItemsResponse<T> : ResponseBase where T : new()
    {
        public DataItemsResponse()
        {
            Data = new DataItemsResponseBody<T>();
        }

        /// <summary>
        /// Gets or sets the data portion of the response.
        /// </summary>
        public DataItemsResponseBody<T> Data { get; set; }
    }
}