using System.Collections.Generic;

namespace CommerceClient.Api.Model
{
    public class FilterFieldResponse
    {
        /// <summary>
        /// aka ProductFilterKind
        /// </summary>
        public string Kind { get; set; }

        public long FilterFieldId { get; set; }
        public string ExtFilterFieldId { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// aka ProductCustomFieldTypes
        /// </summary>
        public string Type { get; set; }

        public bool? IsApplied { get; set; }

        /// <summary>
        /// If field is a number type, marks the upper bound value for items in the result.
        /// </summary>
        public decimal? UpperBound { get; set; }

        /// <summary>
        /// If field is a number type, marks the lower bound value for items in the result.
        /// </summary>
        public decimal? LowerBound { get; set; }

        /// <summary>
        /// If field is a number type, marks the upper bound value for items in the un-filtered result.
        /// </summary>
        public decimal? UpperGrossBound { get; set; }

        /// <summary>
        /// If field is a number type, marks the lower bound value for items in the un-filtered result.
        /// </summary>
        public decimal? LowerGrossBound { get; set; }

        public List<FilterFieldValueResponse> Values { get; set; }
    }
}