using CommerceClient.Api.Model;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class ProductExtensions
    {
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


            var retval = conn.Execute<DataProductListResponse<Product<object>>>(
                restRequest,
                state,
                false
            );

            return retval.Response.Data;
        }
    }
}