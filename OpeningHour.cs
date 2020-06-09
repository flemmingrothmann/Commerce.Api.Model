using System;

namespace Commerce.Api.Model
{
    public class OpeningHour
    {
        public DateTime? ValidityDate { get; set; }
        public TimeSpan? OpenFrom { get; set; }
        public TimeSpan? OpenTo { get; set; }
        public bool IsClosed { get; set; }
        public string Comment { get; set; }
        public bool IsOpenForCollection { get; set; }
        public TimeSpan? CollectOpenFrom { get; set; }
        public TimeSpan? CollectOpenTo { get; set; }
        public int DayOfTheWeek { get; set; }
    }
}