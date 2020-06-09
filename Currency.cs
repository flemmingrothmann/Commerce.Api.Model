namespace Commerce.Api.Model
{
    public class Currency : ResourceResponse
    {
        public int CurrencyId { get; set; }
        public string ExtCurrencyId { get; set; }
        public string DisplayName { get; set; }
        public int UISortOrder { get; set; }
        public string Name { get; set; }

        // ReSharper disable once InconsistentNaming
        public string Iso4217Alpha3 { get; set; }

        // ReSharper disable once InconsistentNaming
        public int Iso4217Numeric { get; set; }
        public string DecimalSeparator { get; set; }
        public int DecimalDigits { get; set; }
        public string DecimalGroupSeparator { get; set; }
        public int GroupSize { get; set; }
        public int PositivePattern { get; set; }
        public int NegativePattern { get; set; }
    }
}