using System;
using System.Collections.Generic;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class AuthenticationExtensions
    {
        public static (List<HeaderSetMessage> HeaderSetMessages, Authentication Data)
            AuthenticateAsCustomer(
                this Connection conn,
                IClientState state,
                string userName,
                string password
            )
        {
            var (headerSetMessages, response) = conn.Execute<DataResponse<Authentication>>(
                new Authenticate
                    {
                        UserName = userName,
                        Password = password,
                        Role = "customer"
                    }
                    .CreateRestRequestJson(
                        Method.POST,
                        "/services/v3/auth/authenticate"
                    ),
                state,
                true
            );
            return (headerSetMessages, response.Data);
        }


        public static (List<HeaderSetMessage> HeaderSetMessages, Authentication Data) AuthenticateAsAnonymous(
            this Connection conn,
            IClientState state,
            Guid? visitorToken
        )
        {
            var (headerSetMessages, response) = conn.Execute<DataResponse<Authentication>>(
                new Authenticate
                {
                    VisitorGuid = visitorToken,
                    Role = "anonymous"
                }.CreateRestRequestJson(
                    Method.POST,
                    "/services/v3/auth/authenticate"
                ),
                state,
                true
            );
            return (headerSetMessages, response.Data);
        }
    }
}