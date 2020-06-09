namespace Commerce.Api.Model
{
    public class ProductListArticleResponse
    {
        public float? Score { get; set; }

        public string NavigateUrl { get; set; }

        public string NavigateText { get; set; }

        public string NavigateTarget { get; set; }

        public int UiSortOrder { get; set; }

        public string Description { get; set; }
    }
}