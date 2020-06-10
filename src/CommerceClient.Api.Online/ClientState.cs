using System;

namespace CommerceClient.Api.Online
{
    public class ClientState : IClientState
    {
        public int? LanguageId { get; set; }
        public int? CurrencyId { get; set; }
        public int? CountryId { get; set; }
        public int? LocationId { get; set; }
        public string PriceListId { get; set; }
        public DateTime? PriceCalculationDate { get; set; }
        public string InventoryCheck { get; set; }
        public int? CustomerId { get; set; }
        public int? SalesPersonId { get; set; }
        public string TicketToken { get; set; }
        public string AuthenticationToken { get; set; }
        public Guid? VisitorId { get; set; }
    }
}