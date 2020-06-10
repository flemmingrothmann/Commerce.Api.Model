namespace CommerceClient.Api.Model.RequestModels
{
    public class BasketContextRequestBody
    {
        public long? LocationKey { get; set; }
        public int? CurrencyKey { get; set; }
        public int? LanguageKey { get; set; }
    }
}