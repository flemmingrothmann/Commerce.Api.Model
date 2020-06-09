// Flemming Rothmann

using System;

namespace Commerce.Api.Model
{
    [Flags]
    public enum CustomerPolicies
    {
        None = 0,

        /// <summary>
        /// The customer is enabled - access from shop front is possible.
        /// </summary>
        Enabled = 1,

        /// <summary>
        /// The customer is allowed to buy, i.e. add to basket.
        /// </summary>
        CanBuy = 1 << 6,

        /// <summary>
        /// This customer can be updated in the current security context.
        /// </summary>
        CanUpdateSellToAddress = 1 << 7,

        /// <summary>
        /// The customer can be deleted in the current security context.
        /// </summary>
        Deletable = 1 << 8,

        /// <summary>
        /// Accessible by shop front
        /// </summary>
        ShopFrontAccess =
            1 <<
            15, // Is here to provide compatibility with json for shopfront. This flag is on all other policies too.
    }
}