using System;
using System.Collections.Generic;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class AuthenticationExtensions
    {
        public static (List<HeaderSetMessage> HeaderSetMessages, AuthenticationResponse Data)
            AuthenticateAsCustomer(
                this Connection conn,
                IClientState state,
                string userName,
                string password
            )
        {
            var (headerSetMessages, response) = conn.Execute<DataResponse<AuthenticationResponse>>(
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
                Includes.Auth
            );
            return (headerSetMessages, response.Data);
        }


        public static (List<HeaderSetMessage> HeaderSetMessages, AuthenticationResponse Data) AuthenticateAsAnonymous(
            this Connection conn,
            IClientState state,
            Guid? visitorToken
        )
        {
            var (headerSetMessages, response) = conn.Execute<DataResponse<AuthenticationResponse>>(
                new Authenticate
                {
                    VisitorGuid = visitorToken,
                    Role = "anonymous"
                }.CreateRestRequestJson(
                    Method.POST,
                    "/services/v3/auth/authenticate"
                ),
                state,
                Includes.Auth
            );
            return (headerSetMessages, response.Data);
        }
    }
}