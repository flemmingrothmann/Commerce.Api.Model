using System;

namespace CommerceClient.Api.Model
{
    [Flags]
    public enum BasketPolicies
    {
        None = 0,

        /// <summary>
        /// The basket is considered out-of-scope, and should not be included in listings.
        /// </summary>
        Closed = 1 << 1,

        /// <summary>
        /// Basket is marked locked, 
        /// </summary>
        Locked = 1 << 2,

        /// <summary>
        /// Basket is considered out-of-scope - but limited operations may be done (f.inst view status)
        /// </summary>
        OrderCreated = 1 << 3,

        /// <summary>
        /// The basket is yours
        /// </summary>
        Owner = 1 << 4,

        /// <summary>
        /// The basket is not yours, but you are supervising it (think: sales person)
        /// </summary>
        Supervisor = 1 << 5,

        /// <summary>
        /// The basket has another identity than your current identity, although it is still considered yours.
        /// This is the case for a basket that was created before you logged in. After log in, it is considered rogue,
        /// as it still has the attributes of a basket belonging to anonymous user.
        /// </summary>
        Rogue = 1 << 6,

        /// <summary>
        /// Checkout is allowed. The basket can be turned into an order in the current context.
        /// </summary>
        CanCheckout = 1 << 7,

        /// <summary>
        /// The basket can be deleted.
        /// </summary>
        Deletable = 1 << 8,

        /// <summary>
        /// Indicates that basket is accessible in the context.
        /// </summary>
        ShopFrontAccess = Owner | Supervisor | Rogue,

        /// <summary>
        /// You may view, but you may not change anything.
        /// </summary>
        ReadOnly = Locked | Closed | OrderCreated | Rogue
    }
}