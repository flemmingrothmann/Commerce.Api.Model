using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.RequestModels
{
    /// <summary>
    /// Json model for pushing sell-to-address.
    /// The object serialization conforms to the v3 api in the sense, that only properties
    /// that er explicitly set will be pushed over the wire.
    /// </summary>
    public class AddressSellToRequest
    {
        private string companyName;

        public string CompanyName
        {
            get => companyName;
            set
            {
                companyName = value;
                CompanyNameIsSet = true;
            }
        }

        public bool ShouldSerializeCompanyName() => CompanyNameIsSet;

        private bool CompanyNameIsSet { get; set; }

        private string attention;

        public string Attention
        {
            get => attention;
            set
            {
                attention = value;
                AttentionIsSet = true;
            }
        }

        public bool ShouldSerializeAttention() => AttentionIsSet;

        private bool AttentionIsSet { get; set; }

        private string name;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                NameIsSet = true;
            }
        }

        public bool ShouldSerializeName() => NameIsSet;

        public bool NameIsSet { get; set; }

        private string address;

        public string Address
        {
            get => address;
            set
            {
                address = value;
                AddressIsSet = true;
            }
        }

        public bool ShouldSerializeAddress() => AddressIsSet;

        private bool AddressIsSet { get; set; }

        private string address2;

        public string Address2
        {
            get => address2;
            set
            {
                address2 = value;
                Address2IsSet = true;
            }
        }

        public bool ShouldSerializeAddress2() => Address2IsSet;

        private bool Address2IsSet { get; set; }

        private string zipCode;

        public string ZipCode
        {
            get => zipCode;
            set
            {
                zipCode = value;
                ZipCodeIsSet = true;
            }
        }

        public bool ShouldSerializeZipCode() => ZipCodeIsSet;

        private bool ZipCodeIsSet { get; set; }

        private string city;

        public string City
        {
            get => city;
            set
            {
                city = value;
                CityIsSet = true;
            }
        }

        public bool ShouldSerializeCity() => CityIsSet;

        private bool CityIsSet { get; set; }

        private int? countryId;

        public int? CountryId
        {
            get => countryId;
            set
            {
                countryId = value;
                CountryIdIsSet = true;
            }
        }

        public bool ShouldSerializeCountryId() => CountryIdIsSet;

        private bool CountryIdIsSet { get; set; }

        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                EmailIsSet = true;
            }
        }

        public bool ShouldSerializeEmail() => EmailIsSet;

        private bool EmailIsSet { get; set; }

        private string reference;

        public string Reference
        {
            get => reference;
            set
            {
                reference = value;
                ReferenceIsSet = true;
            }
        }

        public bool ShouldSerializeReference() => ReferenceIsSet;

        private bool ReferenceIsSet { get; set; }

        private string phoneNumber;

        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                phoneNumber = value;
                PhoneNumberIsSet = true;
            }
        }

        public bool ShouldSerializePhoneNumber() => PhoneNumberIsSet;

        private bool PhoneNumberIsSet { get; set; }

        private string mobilePhoneNumber;

        public string MobilePhoneNumber
        {
            get => mobilePhoneNumber;
            set
            {
                mobilePhoneNumber = value;
                MobilePhoneNumberIsSet = true;
            }
        }

        public bool ShouldSerializeMobilePhoneNumber() => MobilePhoneNumberIsSet;

        private bool MobilePhoneNumberIsSet { get; set; }

        private string faxNumber;

        public string FaxNumber
        {
            get => faxNumber;
            set
            {
                faxNumber = value;
                FaxNumberIsSet = true;
            }
        }

        public bool ShouldSerializeFaxNumber() => FaxNumberIsSet;

        private bool FaxNumberIsSet { get; set; }

        private string vatNumber;

        public string VatNumber
        {
            get => vatNumber;
            set
            {
                vatNumber = value;
                VATNumberIsSet = true;
            }
        }

        public bool ShouldSerializeVatNumber() => VATNumberIsSet;

        private bool VATNumberIsSet { get; set; }

        private string eInvoiceCustomerReference;

        public string EInvoiceCustomerReference
        {
            get => eInvoiceCustomerReference;
            set
            {
                eInvoiceCustomerReference = value;
                EInvoiceCustomerReferenceIsSet = true;
            }
        }

        public bool ShouldSerializeEInvoiceCustomerReference() => EInvoiceCustomerReferenceIsSet;

        private bool EInvoiceCustomerReferenceIsSet { get; set; }

        private string eInvoiceCustomerExtDocNo;

        public string EInvoiceCustomerExtDocNo
        {
            get => eInvoiceCustomerExtDocNo;
            set
            {
                eInvoiceCustomerExtDocNo = value;
                EInvoiceCustomerExtDocNoIsSet = true;
            }
        }

        public bool ShouldSerializeEInvoiceCustomerExtDocNo() => EInvoiceCustomerExtDocNoIsSet;

        private bool EInvoiceCustomerExtDocNoIsSet { get; set; }

        private string eInvoiceCustomerReceiverCode;

        public string EInvoiceCustomerReceiverCode
        {
            get => eInvoiceCustomerReceiverCode;
            set
            {
                eInvoiceCustomerReceiverCode = value;
                EInvoiceCustomerReceiverCodeIsSet = true;
            }
        }

        public bool ShouldSerializeEInvoiceCustomerReceiverCode() => EInvoiceCustomerReceiverCodeIsSet;

        private bool EInvoiceCustomerReceiverCodeIsSet { get; set; }

        private string eInvoiceCustomerIntPostingNo;

        public string EInvoiceCustomerIntPostingNo
        {
            get => eInvoiceCustomerIntPostingNo;
            set
            {
                eInvoiceCustomerIntPostingNo = value;
                EInvoiceCustomerIntPostingNoIsSet = true;
            }
        }

        public bool ShouldSerializeEInvoiceCustomerIntPostingNo() => EInvoiceCustomerIntPostingNoIsSet;

        private bool EInvoiceCustomerIntPostingNoIsSet { get; set; }
    }
}