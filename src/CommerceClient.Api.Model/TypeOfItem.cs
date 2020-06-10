using System;

namespace CommerceClient.Api.Model
{
    public enum TypeOfItem
    {
        /// <summary>
        /// Line references a product
        /// </summary>
        /// <remarks></remarks>
        Product = 1,

        /// <summary>
        /// Line holds a text, but has no reference to origin.
        /// </summary>
        /// <remarks></remarks>
        Text = 2,

        /// <summary>
        /// Line holds an auction, i.e. references a product.
        /// </summary>
        /// <remarks></remarks>
        [Obsolete(
            "Dead feature",
            true
        )]
        AuctionProduct = 3,

        /// <summary>
        /// Line references a product variant.
        /// </summary>
        /// <remarks></remarks>
        ProductVariant = 4,

        /// <summary>
        /// Line references a Logica Product Assortment.
        /// </summary>
        /// <remarks></remarks>
        [Obsolete("Dead feature")] LogicaProductAssortment = 5,

        /// <summary>
        /// Line references a Logica Product Assortment Variant.
        /// </summary>
        /// <remarks></remarks>
        [Obsolete("Dead feature")] LogicaProductAssortmentVariant = 6,

        /// <summary>
        /// Shipment details, method and cost.
        /// </summary>
        /// <remarks></remarks>
        Shipment = 7,

        /// <summary>
        /// Payment details, method and cost.
        /// </summary>
        /// <remarks></remarks>
        Payment = 8,

        /// <summary>
        /// Rebate line. One rebate line may exists for each different ParentBasketLineId.
        /// </summary>
        Rebate = 9,

        /// <summary>
        /// Line references a Logica Product Variant contained in an Assortment.
        /// </summary>
        /// <remarks></remarks>
        [Obsolete("Dead feature")] LogicaProductAssortmentProductVariant = 10,

        /// <summary>
        /// Line references a configured product. This will most likely have child lines of various types, which are closely linked to this line.
        /// </summary>
        /// <remarks></remarks>
        ConfiguredProduct = 11,

        /// <summary>
        /// Line references a kit product. A kit is a product placeholder, made up of a list of other products, treated as a one unit. 
        /// Kit content does not count stock, nor is price considered.
        /// </summary>
        BomProduct = 12,

        /// <summary>
        /// Coupon related
        /// </summary>
        /// <remarks></remarks>
        Coupon = 13,

        Deal = 14,

        DealLine = 15,

        GiftCard = 16
    }
}