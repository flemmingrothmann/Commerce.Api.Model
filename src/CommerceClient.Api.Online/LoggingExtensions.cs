using System;
using System.Collections.Generic;
using System.Text;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class LoggingExtensions
    {
        public static LogRequest WriteLog(
            this Connection conn,
            IClientState state,
            LogRequest logRequest
        )
        {
            var (headerSetMessages, response) = conn.Execute<LogRequest>(
                logRequest.CreateRestRequestJson(
                    Method.POST,
                    "/services/v3/logs/test"
                ),
                state,
                Includes.Hmac
            );
            return response;
        }
    }
}
