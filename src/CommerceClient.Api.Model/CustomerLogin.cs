using System.Collections.Generic;

namespace CommerceClient.Api.Model
{
    public class CustomerLogin
    {
        public int CustomerLoginId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public Language Language { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}