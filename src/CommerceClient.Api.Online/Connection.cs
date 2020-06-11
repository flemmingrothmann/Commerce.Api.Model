using System;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public class Connection
    {
        public static Connection Create(string hostName) => new Connection(hostName);

        public Connection(string hostName)
        {
            HostName = hostName;
            var client = new RestClient(hostName);
            // Override with Newtonsoft JSON Handler
            client.AddHandler(
                "application/json",
                () => NewtonsoftJsonSerializer.Default
            );
            client.AddHandler(
                "text/json",
                () => NewtonsoftJsonSerializer.Default
            );
            client.AddHandler(
                "text/x-json",
                () => NewtonsoftJsonSerializer.Default
            );
            client.AddHandler(
                "text/javascript",
                () => NewtonsoftJsonSerializer.Default
            );
            client.AddHandler(
                "*+json",
                () => NewtonsoftJsonSerializer.Default
            );

            Client = client;
        }

        public string HostName { get; }
        public bool IgnoreSslErrors { get; set; } = true;
        public TimeSpan RequestTimeout { get; set; } = TimeSpan.FromSeconds(30);
        public string HostOverride { get; set; }
        internal IRestClient Client { get; }
    }
}