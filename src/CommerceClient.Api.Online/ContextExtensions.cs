using System.Collections.Generic;
using CommerceClient.Api.Model;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class ContextExtensions
    {
        public static (List<HeaderSetMessage> HeaderSetMessages, Context Data) GetContext(
            this Connection conn,
            IClientState state
        )
        {
            var (headerSetMessages, response) = conn.Execute<DataResponse<Context>>(
                new RestRequest("/services/v3/context")
                {
                    Method = Method.GET
                },
                state,
                Includes.None
            );
            return (headerSetMessages, response.Data);
        }
    }
}