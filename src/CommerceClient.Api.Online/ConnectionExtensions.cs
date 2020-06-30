using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using CommerceClient.Api.Model;
using RestSharp;

namespace CommerceClient.Api.Online
{
    [Flags]
    public enum Includes
    {
        None = 0,
        Auth = 1 << 0,
        Ticket = 1 << 1,
        Hmac = 1 << 2
    }

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
        /// <param name="authHint"></param>
        /// <returns></returns>
        public static (List<HeaderSetMessage> HeaderSetMessages, T Response) Execute<T>(
            this Connection conn,
            IRestRequest restRequest,
            IClientState state,
            Includes authHint
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

            PrepareRequest(
                conn,
                request
            );

            AddContextToRequest(
                request,
                state,
                authHint
            );

            var sw = Stopwatch.StartNew();
            conn.Client.FailOnDeserializationError = false;
            var response = conn.Client.Execute<T>(request);
            sw.Stop();

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                if (response.ErrorException == null)
                {
                    var errResponse = conn.Client.Deserialize<ErrorResponseBase>(response);
                    if (errResponse.Data != null)
                    {
                        throw new NotFoundException(
                            response.StatusCode,
                            errResponse.Data,
                            errResponse.ErrorMessage
                        );
                    }

                    throw new NotFoundException(response.StatusCode.ToString());
                }

                throw new NotFoundException(
                    response.StatusCode,
                    null,
                    response.StatusCode.ToString(),
                    response.ErrorException
                );
            }

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
                var headers = BuildSetHeaders(response);

                return (headers, response.Data);
            }

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new UnauthorizedException(
                    response.StatusCode,
                    response.Headers.Where(x => x.Type == ParameterType.HttpHeader).Select(x => $"{x.Name}: {x.Value}"),
                    response.Headers.Where(
                            x => x.Type == ParameterType.HttpHeader &&
                                 x.Name.Equals(
                                     "WWW-Authenticate",
                                     StringComparison.OrdinalIgnoreCase
                                 )
                        )
                        .Select(x => $"{x.Name}: {x.Value}")
                        .FirstOrDefault()
                );
            }

            var e = conn.Client.Deserialize<ErrorResponseBase>(response);
            if (e?.Data != null)
            {
                throw new ApiException(
                    response.StatusCode,
                    e.Data
                );
            }

            return default;
        }

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
        public static List<HeaderSetMessage> ExecuteNonQuery(
            this Connection conn,
            IRestRequest restRequest,
            IClientState state,
            Includes authHint
        )
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

            PrepareRequest(
                conn,
                request
            );

            AddContextToRequest(
                request,
                state,
                authHint
            );

            var sw = Stopwatch.StartNew();
            var response = conn.Client.Execute(request);
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
                return BuildSetHeaders(response);
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

        /// <summary>
        /// Returns a collection of http Set headers, i.e. X-Set-(some-name).
        /// This is used for signalling state out-of-band.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response"></param>
        /// <returns></returns>
        private static List<HeaderSetMessage> BuildSetHeaders(IRestResponse response)
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

            return headers;
        }

        private static void PrepareRequest(Connection conn, IRestRequest request)
        {
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
        }

        /// <summary>
        /// Adds state information to the request
        /// </summary>
        /// <param name="request"></param>
        /// <param name="state"></param>
        /// <param name="authHint"></param>
        private static void AddContextToRequest(
            IRestRequest request,
            IClientState state,
            Includes authHint
        )
        {
            if ((authHint & Includes.Auth) != 0 && state?.AuthenticationToken != null)
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


            if ((authHint & Includes.Hmac) != 0)
            {
                request.OnBeforeRequest =
                    new HmacHandlerInfo(
                            request,
                            state.ApiKey,
                            state.ApiSecret,
                            state.InstallationId
                        )
                        .ApplyHmac; // TODO: Create an object that handles the delegate, and pass along the http method, as this is needed in the signature!
            }
        }

        private class HmacHandlerInfo
        {
            private string ApiSecret { get; set; }
            private string ApiKey { get; set; }
            private string ApiInstallationId { get; set; }

            private static DateTime Epoch { get; set; } = new DateTime(
                1970,
                01,
                01,
                0,
                0,
                0
            );

            public IRestRequest Request { get; }

            public HmacHandlerInfo(
                IRestRequest request,
                string apiKey,
                string apiSecret,
                string apiInstallationId
            )
            {
                Request = request;
                ApiKey = apiKey;
                ApiSecret = apiSecret;
                ApiInstallationId = apiInstallationId;
            }


            /// <summary>
            /// Intercepts the request just before going over the wire in order to calculate and insert hmacauth validation.
            /// </summary>
            /// <param name="http"></param>
            internal void ApplyHmac(IHttp http)
            {
                var secretBytes = http.Encoding.GetBytes(ApiSecret ?? string.Empty);
                var apiKey = ApiKey ?? string.Empty;
                var installationId = ApiInstallationId ?? string.Empty;

                var bodyBytes = http.RequestBodyBytes ?? http.Encoding.GetBytes(http.RequestBody ?? string.Empty);

                var httpverb = Request.Method.ToString();
                var entireUrl = (http.Host ?? http.Url.Host) + http.Url.PathAndQuery;
                string bodyHashString;
                using (var bodyHmac = new HMACSHA256(secretBytes))
                {
                    bodyHashString = Convert.ToBase64String(bodyHmac.ComputeHash(bodyBytes));
                }

                var nonce = Guid.NewGuid().ToString();
                var unixTimeStamp = Convert.ToInt32((DateTime.UtcNow - Epoch).TotalSeconds).ToStringConfigStyle();
                var headersInSignature = string.Empty;

                // Intend to use SHA256 both for body and signature hashes
                var hashMethods = "SHA256/SHA256";

                /// Creating the signature
                var signaturePlainText = new StringBuilder();
                signaturePlainText.Append(apiKey);
                signaturePlainText.Append(installationId);
                signaturePlainText.Append(httpverb);
                signaturePlainText.Append(entireUrl);
                signaturePlainText.Append(bodyHashString);
                signaturePlainText.Append(nonce);
                signaturePlainText.Append(unixTimeStamp);
                signaturePlainText.Append(headersInSignature);

                string signature;

                using (var signatureHmac = new HMACSHA256(secretBytes))
                {
                    signature = Convert.ToBase64String(
                        signatureHmac.ComputeHash(
                            http.Encoding.GetBytes(
                                signaturePlainText.ToString()
                            )
                        )
                    );
                }

                http.Headers.Add(
                    new HttpHeader(
                        "Authorization",
                        $"hmacauth {hashMethods}:{apiKey}:{installationId}:{signature}:{nonce}:{unixTimeStamp}"
                    )
                );
            }
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
            if (connection == null)
            {
                throw new ArgumentNullException(nameof(connection));
            }

            if (resource == null)
            {
                throw new ArgumentNullException(nameof(resource));
            }

            var restRequest = new RestRequest(resource)
            {
                Method = method,
                RequestFormat = DataFormat.Json,
                JsonSerializer = NewtonsoftJsonSerializer.Default
            };

            return restRequest;
        }
    }
}