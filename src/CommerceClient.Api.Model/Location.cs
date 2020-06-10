using System;
using System.Collections.Generic;

namespace CommerceClient.Api.Model
{
    public class Location
    {
        public long LocationId { get; set; }
        public string ExtLocationId { get; set; }
        public string PosId { get; set; }
        public bool IsDefault { get; set; }
        public bool IsBuyable { get; set; }
        public bool ShowAddToBasket { get; set; }
        public int UiSortorder { get; set; }
        public string LocationName { get; set; }
        public bool IsVisibleInShop { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string County { get; set; }
        public int? CountryId { get; set; }
        public string EmailAddress { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public TimeSpan? LeadTime { get; set; }
        public List<OpeningHour> OpeningHours { get; set; }
        public List<OpeningHour> SpecialOpeningHours { get; set; }
        public List<DateTime> CollectTimes { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}