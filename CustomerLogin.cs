namespace Commerce.Api.Model
{
    public class CustomerLogin : ResourceResponse
    {
        public int CustomerLoginId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public Language Language { get; set; }
    }
}