using System.Collections.Generic;

namespace Commerce.Api.Model
{
    public class DataItemsResponseBody<T> where T : new()
    {
        /// <summary>
        /// Any validation message(s) that may (or may not) accompany the output.
        /// </summary>
        public List<ValidationMessageResponse> Messages { get; set; }

        /// <summary>
        /// The kind property serves as a guide to what type of information this particular <see cref="Items"/> property stores. 
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets the number of occurences in <see cref="Items"/> list.
        /// </summary>
        public int CurrentItemCount => Items?.Count ?? 0;

        /// <summary>
        /// If the <see cref="Items"/> list is not complete, you should specify the total item count here.
        /// </summary>
        public int? TotalItems { get; set; }

        /// <summary>
        /// Total number of items before any filtering .
        /// </summary>
        public int GrossItems { get; set; }

        /// <summary>
        /// For paging. 
        /// </summary>
        public int? ItemsPerPage { get; set; }

        /// <summary>
        /// For paging. 1-based index of the first item in <see cref="Items"/> collection.
        /// </summary>
        public int? StartIndex { get; set; }

        /// <summary>
        /// For paging. 
        /// </summary>
        public string PagingLinkTemplate { get; set; }

        /// <summary>
        /// For paging. 
        /// </summary>
        public int? PageIndex { get; set; }

        /// <summary>
        /// For paging. 
        /// </summary>
        public int? TotalPages { get; set; }

        /// <summary>
        /// For paging. 
        /// </summary>
        public string NextLink { get; set; }

        /// <summary>
        /// For paging. 
        /// </summary>
        public string PreviousLink { get; set; }

        ///// <summary>
        ///// Optional attributes for the items or the entity holding the items.
        ///// This is optional.
        ///// </summary>
        // public object Attributes { get; set; }

        /// <summary>
        /// Items array
        /// </summary>
        public List<T> Items { get; set; }
    }
}