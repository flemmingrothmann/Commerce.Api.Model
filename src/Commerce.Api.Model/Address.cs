using System.Collections.Generic;
using Newtonsoft.Json;

namespace Commerce.Api.Model
{
    public class Address
    {
        public bool? IsEnabled { get; set; }
        public bool? IsConfirmed { get; set; }
        public List<InputFieldPolicyResponse> Constraints { get; set; }
        public string CompanyName { get; set; }
        public string Attention { get; set; }
        public string Name { get; set; }

        [JsonProperty("Address")] public string StreetName { get; set; }

        [JsonProperty("Address2")] public string StreetName2 { get; set; }

        public string ZipCode { get; set; }
        public string City { get; set; }

        public Country Country { get; set; }

        //public int? CountryId { get; set; }
        //public string Country { get; set; }
        //public string ExtCountryId { get; set; }
        //public string CountryIso3166Alpha3 { get; set; }
        public string Email { get; set; }
        public string Reference { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string VATNumber { get; set; }
        public string EInvoiceCustomerReference { get; set; }
        public string EInvoiceCustomerExtDocNo { get; set; }
        public string EInvoiceCustomerReceiverCode { get; set; }
        public string EInvoiceCustomerIntPostingNo { get; set; }
    }
}