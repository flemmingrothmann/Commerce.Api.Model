namespace Commerce.Api.Model
{
    public class DataResponse<T> : ResponseBase where T : new()
    {
        /// <summary>
        /// Gets or sets the data portion of the response.
        /// </summary>
        public T Data { get; set; }
    }
}