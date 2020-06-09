using System;
using System.Runtime.Serialization;

namespace Commerce.Api.Model
{
    [Serializable]
    //[ProtoBuf.ProtoContract]
    public struct ItemStringKey : IComparable<ItemStringKey>, ISerializable
    {
        /// <summary>
        /// A <see cref="ItemStringKey"/>, that does not exist in any model. It has the same meaning as null (Nothing).
        /// </summary>
        public static readonly ItemStringKey NonExistent = new ItemStringKey(
            "-one-!egged-dogs-cannot-run-",
            -1
        );

        /// <summary>
        /// Creates a new ItemStringKey by itemId and typeOfItemId (int representation of TypeOfItem)
        /// </summary>
        public ItemStringKey(string itemId, int typeOfItemId)
        {
            _ItemId = itemId;
            _TypeOfItem = (TypeOfItem) typeOfItemId;
        }

        /// <summary>
        /// Creates a new ItemStringKey by itemId and TypeOfItem
        /// </summary>
        public ItemStringKey(string itemId, TypeOfItem kind)
        {
            _ItemId = itemId;
            _TypeOfItem = kind;
        }

        // ReSharper disable once UnusedParameter.Local
        private ItemStringKey( SerializationInfo info, StreamingContext text)
            : this()
        {
            _ItemId = info.GetString("i");
            _TypeOfItem = (TypeOfItem) info.GetInt32("k");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(
                "i",
                _ItemId
            );
            info.AddValue(
                "k",
                _TypeOfItem
            );
        }


        private static int BuildHashCode(string itemId, TypeOfItem kind)
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
        private readonly string _ItemId;

        //[ProtoBuf.ProtoMember(2)]
        private readonly TypeOfItem _TypeOfItem;

        public string ItemId => _ItemId;
        public TypeOfItem TypeOfItem => _TypeOfItem;

        public override int GetHashCode() => BuildHashCode(
            _ItemId,
            _TypeOfItem
        );

        public override bool Equals(object obj) => obj is ItemStringKey && this == (ItemStringKey) obj;

        public static bool operator ==(ItemStringKey x, ItemStringKey y)
            => x.ItemId == y.ItemId && x.TypeOfItem == y.TypeOfItem;

        public static bool operator !=(ItemStringKey x, ItemStringKey y) => !(x == y);

        public static bool operator <(ItemStringKey x, ItemStringKey y)
            => x.TypeOfItem < y.TypeOfItem ||
               x.TypeOfItem == y.TypeOfItem &&
               string.Compare(
                   x.ItemId,
                   y.ItemId,
                   StringComparison.OrdinalIgnoreCase
               ) <
               0;

        public static bool operator <=(ItemStringKey x, ItemStringKey y)
            => x.TypeOfItem < y.TypeOfItem ||
               x.TypeOfItem == y.TypeOfItem &&
               string.Compare(
                   x.ItemId,
                   y.ItemId,
                   StringComparison.OrdinalIgnoreCase
               ) <=
               0;

        public static bool operator >(ItemStringKey x, ItemStringKey y)
            => x.TypeOfItem > y.TypeOfItem ||
               x.TypeOfItem == y.TypeOfItem &&
               string.Compare(
                   x.ItemId,
                   y.ItemId,
                   StringComparison.OrdinalIgnoreCase
               ) >
               0;

        public static bool operator >=(ItemStringKey x, ItemStringKey y)
            => x.TypeOfItem > y.TypeOfItem ||
               x.TypeOfItem == y.TypeOfItem &&
               string.Compare(
                   x.ItemId,
                   y.ItemId,
                   StringComparison.OrdinalIgnoreCase
               ) >=
               0;


        public int CompareTo(ItemStringKey other) => this == other
                                                         ? 0
                                                         : this > other
                                                             ? 1
                                                             : -1;

        public override string ToString() => $"[{TypeOfItem}, \"{ItemId}\"]";
    }
}