using System;
using System.Collections.Generic;
using System.Text;

namespace Commerce.Api.Model.RequestModels
{
    public class BasketContextRequestBody
    {
        public long? LocationKey { get; set; }
        public int? CurrencyKey { get; set; }
        public int? LanguageKey { get; set; }
    }
}