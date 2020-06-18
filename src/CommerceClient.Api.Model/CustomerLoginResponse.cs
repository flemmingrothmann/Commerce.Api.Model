using System.Collections.Generic;

namespace CommerceClient.Api.Model
{
    public class CustomerLoginResponse
    {
        public int CustomerLoginId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Currency Currency { get; set; }
        public Language Language { get; set; }
        public List<ResourceLink> Links { get; set; }
        public List<InputFieldPolicyResponse> Constraints { get; set; }
    }
}