using System.Collections.Generic;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class BasketExtensions
    {
        public static BasketResponse CreateNewBasket(
            this Connection conn,
            ClientState state
        )
        {
            return conn.Execute<DataResponse<BasketResponse>>(
                    conn.CreateRestRequestJson(
                        Method.POST,
                        "/services/v3/baskets"
                    ),
                    state,
                    true
                )
                .Response.Data;
        }

        public static List<BasketLineResponse> GetBasketLines(
            this Connection conn,
            IClientState state,
            int basketId
        )
        {
            var restRequest = conn.CreateRestRequestJson(Method.GET, "/services/v3/baskets/{basketId}/lines")
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                ).AddParameter(
                    "include",
                    "description",
                    ParameterType.QueryString
                );


            var (_, response) = conn.Execute<DataItemsResponse<BasketLineResponse>>(
                restRequest,
                state,
                true
            );

            return response.Data.Items;
        }

        public static List<ValidationMessageResponse> AddToBasket(
            this Connection conn,
            ClientState state,
            int basketId,
            List<BasketLineRequestBody> items
        ) =>
            conn.Execute<DataItemsResponse<ValidationMessageResponse>>(
                    items.CreateRestRequestJson(
                            Method.POST,
                            "/services/v3/baskets/{basketId}/lines"
                        )
                        .AddParameter(
                            "basketId",
                            basketId,
                            ParameterType.UrlSegment
                        ),
                    state,
                    true
                )
                .Response.Data?.Items;

        public static void DeleteBasketLine(
            this Connection conn,
            ClientState state,
            int basketId,
            int basketLineId
        )
        {
            conn.Execute<object>(
                conn.CreateRestRequestJson(
                        Method.DELETE,
                        "/services/v3/baskets/{basketId}/lines/{lineId}"
                    )
                    .AddParameter(
                        "basketId",
                        basketId,
                        ParameterType.UrlSegment
                    )
                    .AddParameter(
                        "lineId",
                        basketLineId,
                        ParameterType.UrlSegment
                    ),
                state,
                true
            );
        }

        public static BasketResponse GetBasket(
            this Connection conn,
            IClientState state,
            int basketId
        )
        {
            var restRequest = conn.CreateRestRequestJson(Method.GET, "/services/v3/baskets/{basketId}")
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                )
                .AddParameter(
                    "include",
                    "description",
                    ParameterType.QueryString
                );


            var (_, response) = conn.Execute<DataResponse<BasketResponse>>(
                restRequest,
                state,
                true
            );

            return response.Data;
        }

        public static List<BasketResponse> GetBaskets(this Connection conn, IClientState state)
        {
            var restRequest = new RestRequest("/services/v3/baskets")
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            restRequest.AddParameter(
                "include",
                "description",
                ParameterType.QueryString
            );


            var (_, response) = conn.Execute<DataItemsResponse<BasketResponse>>(
                restRequest,
                state,
                true
            );

            return response.Data.Items;
        }
    }
}