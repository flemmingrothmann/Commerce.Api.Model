using Newtonsoft.Json;

namespace CommerceClient.Api.Model
{
    public class AuthenticationResponse
    {
        /// <summary>
        /// This is the same as set in authentication header
        /// </summary>
        [JsonProperty("Authentication")]
        public string AuthenticationToken { get; set; }

        /// <summary>
        /// This is the same as set in ticket header
        /// </summary>
        public string Ticket { get; set; }

        public CustomerLoginResponse CustomerLogin { get; set; }
        public SalesPersonLogin SalesPersonLogin { get; set; }

        public string Role { get; set; }

        /// <summary>
        /// How long time in seconds you can rely on this authentication.
        /// If the authentication gets older that this, it should be renewed.
        /// Why? For two reasons:
        /// 1 - to ensure your authentication does not expire with rejected calls as a result, and
        /// 2 - the Ticket part of the response is used to establish scope for responses, and responses are
        /// cached based on this scope. Using the same ticket for extended amount of time means you will
        /// more hits from cache, but also the likelihood of getting stale data from cache will also rise.
        /// </summary>
        public int Ttl { get; set; }
    }
}