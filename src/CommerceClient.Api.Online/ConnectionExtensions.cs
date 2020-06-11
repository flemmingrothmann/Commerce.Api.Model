using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CommerceClient.Api.Model;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class ConnectionExtensions
    {
        public const string ErrorResponseKey = "ErrorResponse";


        /// <summary>
        /// Executes a rest request, returning the response. If the request fails, an exception is thrown.
        /// Look at the exception Data property with key 'ErrorResponse' to find
        /// the corresponding error response - if any - which is of type <see cref="ErrorResponseBase"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="restRequest"></param>
        /// <param name="state"></param>
        /// <param name="includeAuthentication"></param>
        /// <returns></returns>
        public static (List<HeaderSetMessage> HeaderSetMessages, T Response) Execute<T>(
            this Connection conn,
            IRestRequest restRequest,
            IClientState state,
            bool includeAuthentication
        )
            where T : new()
        {
            if (conn == null)
            {
                throw new ArgumentNullException(nameof(conn));
            }

            if (restRequest == null)
            {
                throw new ArgumentNullException(nameof(restRequest));
            }

            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }

            if (conn == null)
            {
                throw new ArgumentNullException(nameof(conn));
            }

            var request =
                restRequest;

            request.Timeout = Convert.ToInt32(conn.RequestTimeout.TotalMilliseconds);
            if (!request.Parameters.Any(x => x.Type == ParameterType.HttpHeader && x.Name == "Accept"))
            {
                request.AddHeader(
                    "Accept",
                    "application/Json,text/json"
                );
            }

            if (conn.IgnoreSslErrors)
            {
                request.AddHeader(
                    EndPointManagerServiceCertificateCallbackHack.IgnoreSslErrorsHeaderKey,
                    "true"
                );
            }

            if (conn.HostOverride != null)
            {
                request.AddHeader(
                    "X-HostOverride",
                    conn.HostOverride
                );
            }

            /*
             * Inject context
             */
            if (includeAuthentication && state?.AuthenticationToken != null)
            {
                request.AddParameter(
                    "X-Authentication",
                    state.AuthenticationToken,
                    ParameterType.HttpHeader
                );
            }

            if (state?.LanguageId != null)
            {
                request.AddParameter(
                    "langId",
                    state.LanguageId,
                    ParameterType.QueryString
                );
            }

            if (state?.CurrencyId != null)
            {
                request.AddParameter(
                    "currId",
                    state.CurrencyId,
                    ParameterType.QueryString
                );
            }

            if (state?.CountryId != null)
            {
                request.AddParameter(
                    "counId",
                    state.CountryId,
                    ParameterType.QueryString
                );
            }

            if (state?.LocationId != null)
            {
                request.AddParameter(
                    "locId",
                    state.LocationId,
                    ParameterType.QueryString
                );
            }
            /*
             * End context injection
             */


            var sw = Stopwatch.StartNew();
            var response = conn.Client.Execute<T>(request);
            sw.Stop();

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new Exception(
#pragma warning disable CA1303 // Do not pass literals as localized parameters Localization!
                    message,
#pragma warning restore CA1303 // Do not pass literals as localized parameters
                    response.ErrorException
                );
            }

            if (response.IsSuccessful)
            {
                var headers = new List<HeaderSetMessage>();

                foreach (var responseHeader in response.Headers.Where(
                    x =>
                        x.Type == ParameterType.HttpHeader &&
                        x.Name.StartsWith(
                            "X-Set-",
                            StringComparison.OrdinalIgnoreCase
                        )
                ))
                {
                    var headerSet = new HeaderSetMessage();

                    if (responseHeader.Value is string responseHeaderValue)
                    {
                        headerSet.Name = responseHeader.Name.Substring(6);

                        var strings = responseHeaderValue.Split(";".ToCharArray());

                        headerSet.Value = strings[0] == "null" ? null : strings[0];

                        if (strings.Length > 1)
                        {
                            headerSet.Priority = strings[1];
                        }

                        headers.Add(headerSet);
                    }
                }

                return (headers, response.Data);
            }

            var e = conn.Client.Deserialize<ErrorResponseBase>(response);
            if (e?.Data != null)
            {
                var ex = new Exception();
                ex.Data.Add(
                    ErrorResponseKey,
                    e.Data
                );
                throw ex;
            }

            return default;
        }


        internal static RestRequest CreateRestRequestJson<T>(
            this T body,
            Method method,
            string resource
        )
        {
            var restRequest = new RestRequest(resource)
            {
                Method = method,
                RequestFormat = DataFormat.Json,
                JsonSerializer = NewtonsoftJsonSerializer.Default
            };

            restRequest.AddJsonBody(body);
            return restRequest;
        }

        /// <summary>
        /// Creates a new json <see cref="RestRequest"/>.
        /// </summary>
        internal static RestRequest CreateRestRequestJson(
            this Connection connection,
            Method method,
            string resource
        )
        {
            var restRequest = new RestRequest(resource)
            {
                Method = method,
                RequestFormat = DataFormat.Json,
                JsonSerializer = NewtonsoftJsonSerializer.Default
            };

            return restRequest;
        }

        /// <summary>
        /// Creates a new json <see cref="RestRequest"/> using the instance as body.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method"></param>
        /// <param name="resource"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static RestRequest GetRestRequestJson<T>(
            Method method,
            string resource,
            T body
        )
        {
            var restRequest = new RestRequest(resource)
            {
                Method = method,
                RequestFormat = DataFormat.Json,
                JsonSerializer = NewtonsoftJsonSerializer.Default
            };

            restRequest.AddJsonBody(body);
            return restRequest;
        }
    }
}