using System;

namespace Commerce.Api.Model.RequestModels
{
    public class Authenticate
    {
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid? VisitorGuid { get; set; }
    }
}