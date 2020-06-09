namespace Commerce.Api.Model
{
    public class SimpleQuantifiedMeasureResponse
    {
        public decimal Amount { get; set; }
        public int UnitOfMeasureId { get; set; }
        public string Abbreviation { get; set; }
    }
}