using System;
using System.Runtime.Serialization;

namespace CommerceClient.Api.Model
{
    /// <summary>
    /// Forms a natural key for items within eSeller, combining referencing Item id and the Item kind id into a single structure.
    /// The kind of item is determined the the typeOfItem portion if this key.
    /// </summary>
    [Serializable]
    public struct ItemKey : IComparable<ItemKey>, ISerializable, IEquatable<ItemKey>
    {
        /// <summary>
        /// A <see cref="ItemKey"/>, that does not exist in any model. It has the same meaning as null (Nothing).
        /// </summary>
        public static readonly ItemKey NonExistent = new ItemKey(
            -1,
            -1
        );

        /// <summary>
        /// Creates a new ItemKey by itemId and typeOfItemId (int representation of TypeOfItem)
        /// </summary>
        public ItemKey(int itemId, int typeOfItemId)
        {
            _ItemId = itemId;
            _TypeOfItem = (TypeOfItem) typeOfItemId;
        }

        /// <summary>
        /// Creates a new ItemKey by itemId and typeOfItemId (int representation of TypeOfItem)
        /// </summary>
        public ItemKey(long itemId, int typeOfItemId)
        {
            if (itemId > int.MaxValue || itemId < int.MinValue)
            {
                throw new InvalidCastException($"itemId value {itemId} is outside of integer range.");
            }

            _ItemId = (int) itemId;
            _TypeOfItem = (TypeOfItem) typeOfItemId;
        }

        /// <summary>
        /// Creates a new ItemKey by itemId and TypeOfItem
        /// </summary>
        public ItemKey(int itemId, TypeOfItem kind)
        {
            _ItemId = itemId;
            _TypeOfItem = kind;
        }

        /// <summary>
        /// Creates a new ItemKey by itemId and TypeOfItem
        /// </summary>
        public ItemKey(long itemId, TypeOfItem kind)
        {
            if (itemId > int.MaxValue || itemId < int.MinValue)
            {
                throw new InvalidCastException($"itemId value {itemId} is outside of integer range.");
            }

            _ItemId = (int) itemId;
            _TypeOfItem = kind;
        }

        private ItemKey(SerializationInfo info, StreamingContext text)
            : this()
        {
            _ItemId = info.GetInt32("i");
            _TypeOfItem = (TypeOfItem) info.GetInt32("k");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                return;
            }

            info.AddValue(
                "i",
                _ItemId
            );
            info.AddValue(
                "k",
                _TypeOfItem
            );
        }


        private static int BuildHashCode(int itemId, TypeOfItem kind)
        {
            unchecked // Overflow is fine, just wrap
            {
                var hash = 17;
                hash = hash * 23 + itemId.GetHashCode();
                hash = hash * 23 + kind.GetHashCode();
                return hash;
            }
        }

        //[ProtoBuf.ProtoMember(1)]
        private readonly int _ItemId;

        //[ProtoBuf.ProtoMember(2)]
        private readonly TypeOfItem _TypeOfItem;

        public int ItemId => _ItemId;
        public TypeOfItem TypeOfItem => _TypeOfItem;

        public override int GetHashCode() => BuildHashCode(
            _ItemId,
            _TypeOfItem
        );

        ///// <summary>
        ///// <inheritdoc />
        ///// </summary>
        //public int RedisCacheTtlMinutes => DocumentCacheConfiguration.Current.CacheTTLMinutesProduct;

        ///// <summary>
        ///// <inheritdoc />
        ///// </summary>
        //public string BuildCacheKey() => $"Item[{TypeOfItem}, {ItemId}]";

        public override bool Equals(object obj) => obj is ItemKey && this == (ItemKey) obj;

        public static bool operator ==(ItemKey x, ItemKey y) => x.ItemId == y.ItemId && x.TypeOfItem == y.TypeOfItem;

        public static bool operator !=(ItemKey x, ItemKey y) => !(x == y);

        public static bool operator <(ItemKey x, ItemKey y)
            => x.TypeOfItem < y.TypeOfItem || x.TypeOfItem == y.TypeOfItem && x.ItemId < y.ItemId;

        public static bool operator <=(ItemKey x, ItemKey y)
            => x.TypeOfItem < y.TypeOfItem || x.TypeOfItem == y.TypeOfItem && x.ItemId <= y.ItemId;

        public static bool operator >(ItemKey x, ItemKey y)
            => x.TypeOfItem > y.TypeOfItem || x.TypeOfItem == y.TypeOfItem && x.ItemId > y.ItemId;

        public static bool operator >=(ItemKey x, ItemKey y)
            => x.TypeOfItem > y.TypeOfItem || x.TypeOfItem == y.TypeOfItem && x.ItemId >= y.ItemId;


        public int CompareTo(ItemKey other) => this == other
                                                   ? 0
                                                   : this > other
                                                       ? 1
                                                       : -1;

        public override string ToString() => $"[{TypeOfItem}, {ItemId}]";

        public bool Equals(ItemKey other)
            => this == other;
    }
}