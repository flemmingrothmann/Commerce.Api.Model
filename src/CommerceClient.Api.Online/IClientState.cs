namespace CommerceClient.Api.Online
{
    public interface IClientState
    {
        int? LanguageId { get; }
        int? CurrencyId { get; }
        int? CountryId { get; }
        int? LocationId { get; }
        string TicketToken { get; }
        string AuthenticationToken { get; }
        string ApiKey { get; }
        string ApiSecret { get; }
        string InstallationId { get; }
    }
}