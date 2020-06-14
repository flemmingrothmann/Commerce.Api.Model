using System.Collections.Generic;
using System.Linq;
using CommerceClient.Api.Model;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class ProductExtensions
    {
        public static DataProductListResponseBody<Product<object>> ProductsByItemKeys(
            this Connection conn,
            IClientState state,
            IEnumerable<ItemKey> itemKeys,
            IEnumerable<int> imageSizeTypes,
            string sortOption,
            int? page,
            int? pageSize,
            int? maxSearchResults,
            string includes // "shortdesc,longdesc,seo"
        )
        {
            var itemKeysJson = string.Join(
                ",",
                itemKeys.Select(x => x.ToJsonString()).ToList()
            );
            var restRequest = conn.CreateRestRequestJson(
                    Method.GET,
                    "/services/v3/products"
                )
                .AddParameter(
                    "itemkeys",
                    $"[{itemKeysJson}]",
                    ParameterType.QueryString
                );

            if (imageSizeTypes != null)
            {
                restRequest.AddParameter(
                    "imagesizetypeids",
                    string.Join(
                        ",",
                        imageSizeTypes
                    ),
                    ParameterType.QueryString
                );
            }

            if (!string.IsNullOrWhiteSpace(includes))
            {
                restRequest.AddParameter(
                    "include",
                    includes,
                    ParameterType.QueryString
                );
            }

            if (sortOption.ToNullIfWhite() != null)
            {
                restRequest.AddParameter(
                    "sort",
                    sortOption,
                    ParameterType.QueryString
                );
            }


            if (page != null)
            {
                restRequest.AddParameter(
                    "p",
                    page,
                    ParameterType.QueryString
                );
            }

            if (pageSize != null)
            {
                restRequest.AddParameter(
                    "rp",
                    pageSize,
                    ParameterType.QueryString
                );
            }

            if (maxSearchResults != null)
            {
                restRequest.AddParameter(
                    "maxSearchResults",
                    maxSearchResults,
                    ParameterType.QueryString
                );
            }


            var (_, response) = conn.Execute<DataProductListResponse<Product<object>>>(
                restRequest,
                state,
                false
            );

            return response.Data;
        }


        public static DataProductListResponseBody<Product<object>> ProductSearch(
            this Connection conn,
            IClientState state,
            string searchString,
            int? menuId,
            string sortOption,
            int? page,
            int? pageSize,
            int? maxSearchResults
        )
        {
            var restRequest = conn.CreateRestRequestJson(
                    Method.GET,
                    "/services/v3/products/list"
                )
                .AddParameter(
                    "imagesizetypeids",
                    1,
                    ParameterType.QueryString
                );

            if (searchString.ToNullIfWhite() != null)
            {
                restRequest.AddParameter(
                    "search",
                    searchString,
                    ParameterType.QueryString
                );
            }

            if (sortOption.ToNullIfWhite() != null)
            {
                restRequest.AddParameter(
                    "sort",
                    sortOption,
                    ParameterType.QueryString
                );
            }

            if (menuId != null)
            {
                restRequest.AddParameter(
                    "mId",
                    menuId,
                    ParameterType.QueryString
                );
            }

            if (page != null)
            {
                restRequest.AddParameter(
                    "p",
                    page,
                    ParameterType.QueryString
                );
            }

            if (pageSize != null)
            {
                restRequest.AddParameter(
                    "rp",
                    pageSize,
                    ParameterType.QueryString
                );
            }

            if (maxSearchResults != null)
            {
                restRequest.AddParameter(
                    "maxSearchResults",
                    maxSearchResults,
                    ParameterType.QueryString
                );
            }


            var (_, response) = conn.Execute<DataProductListResponse<Product<object>>>(
                restRequest,
                state,
                false
            );

            return response.Data;
        }

        /// <summary>
        /// Returns the content as a json representation. Used for passing info to ui.
        /// </summary>
        internal static string ToJsonString(this ItemKey k)
            => $"{{\"itemId\":\"{k.ItemId}\",\"typeOfItem\":\"{k.TypeOfItem}\"}}";
    }
}