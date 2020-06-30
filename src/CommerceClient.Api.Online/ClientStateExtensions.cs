using System;
using System.Collections.Generic;
using System.Text;
using CommerceClient.Api.Model;

namespace CommerceClient.Api.Online
{
    public static class ClientStateExtensions
    {
        public static ClientState ChangeState(this ClientState state, List<HeaderSetMessage> setHeaders)
        {
            var clientContext = new ClientState
            {
                AuthenticationToken = state.AuthenticationToken,
                CountryId = state.CountryId,
                CurrencyId = state.CurrencyId,
                CustomerId = state.CustomerId,
                InventoryCheck = state.InventoryCheck,
                LanguageId = state.LanguageId,
                LocationId = state.LocationId,
                PriceCalculationDate = state.PriceCalculationDate,
                PriceListId = state.PriceListId,
                SalesPersonId = state.SalesPersonId,
                TicketToken = state.TicketToken
            };
            if (setHeaders != null)
            {
                foreach (var headerSetMessage in setHeaders)
                {
                    switch (headerSetMessage.Name)
                    {
                        case "LangId":
                            clientContext.LanguageId = headerSetMessage.Value.ToIntegerConfigStyle();
                            break;

                        case "CurrId":
                            clientContext.CurrencyId = headerSetMessage.Value.ToIntegerConfigStyle();
                            break;
                        case "CounId":
                            clientContext.CountryId = headerSetMessage.Value.ToIntegerConfigStyle();
                            break;
                        case "LocId":
                            clientContext.LocationId = headerSetMessage.Value.ToIntegerConfigStyle();
                            break;
                        case "Authentication":
                            clientContext.AuthenticationToken = headerSetMessage.Value;
                            break;
                        case "Ticket":
                            clientContext.TicketToken = headerSetMessage.Value;
                            break;
                        case "PriceListId":
                            clientContext.PriceListId = headerSetMessage.Value;
                            break;
                        case "PriceCalculationDate":
                            if (DateTime.TryParse(
                                headerSetMessage.Value,
                                out var dt
                            ))
                            {
                                clientContext.PriceCalculationDate = dt;
                            }
                            else
                            {
                                clientContext.PriceCalculationDate = null;
                            }

                            break;
                        
                        case "InventoryCheck":
                            clientContext.InventoryCheck = headerSetMessage.Value;
                            break;
                        
                        case "CustomerId":
                            clientContext.CustomerId = headerSetMessage.Value.ToIntegerConfigStyle();
                            break;

                        case "SalesPersonId":
                            clientContext.SalesPersonId = headerSetMessage.Value.ToIntegerConfigStyle();
                            break;

                        case "VisitorId":
                            clientContext.VisitorId = headerSetMessage.Value.ToGuid() ?? clientContext.VisitorId;
                            break;

                        case "ApiKey":
                            clientContext.ApiKey = headerSetMessage.Value;
                            break;

                        case "ApiSecret":
                            clientContext.ApiSecret = headerSetMessage.Value;
                            break;

                        case "ApiInstallationId":
                            clientContext.InstallationId = headerSetMessage.Value;
                            break;

                        default:
                            break;
                    }
                }
            }

            return clientContext;
        }
    }
}