namespace CommerceClient.Api.Model
{
    public class DataProductListResponse<T> : ResponseBase where T : new()
    {
        /// <summary>
        /// Gets or sets the data portion of the response.
        /// </summary>
        public DataProductListResponseBody<T> Data { get; set; }
    }
}