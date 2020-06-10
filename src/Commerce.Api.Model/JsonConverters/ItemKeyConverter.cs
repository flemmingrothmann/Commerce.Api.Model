using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Commerce.Api.Model.JsonConverters
{
    public class ItemKeyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ItemKey);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            var obj = JObject.Load(reader);
            var menuId = (int) obj["itemId"];

            switch (((string) obj["typeOfItem"])?.ToLowerInvariant())
            {
                case "product":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.Product
                    );
                case "text":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.Text
                    );
                case "variant":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.ProductVariant
                    );
                case "shipment":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.Shipment
                    );
                case "payment":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.Payment
                    );
                case "rebate":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.Rebate
                    );
                case "productconfiguration":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.ConfiguredProduct
                    );
                case "bom":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.BomProduct
                    );
                case "coupon":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.Coupon
                    );
                case "offer":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.Deal
                    );
                case "offerline":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.DealLine
                    );
                case "giftcard":
                    return new ItemKey(
                        menuId,
                        TypeOfItem.GiftCard
                    );

                default:
                    if (!Enum.TryParse(
                        (string) obj["typeOfItem"] ?? string.Empty,
                        true,
                        out TypeOfItem mk
                    ))
                        throw new Exception($"typeOfItem {(string) obj["typeOfItem"]} is not supported.");

                    return new ItemKey(
                        menuId,
                        mk
                    );
            }
        }

        public override bool CanWrite => true;

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer
        )
        {
            if (value == null)
            {
                writer.WriteNull();
            }
            else
            {
                var mk = (ItemKey) value;

                writer.WriteStartObject();
                writer.WritePropertyName("itemId");
                writer.WriteValue(mk.ItemId);
                writer.WritePropertyName("typeOfItem");
                switch (mk.TypeOfItem)
                {
                    case TypeOfItem.Product:
                        writer.WriteValue("product");
                        break;
                    case TypeOfItem.Text:
                        writer.WriteValue("text");
                        break;
                    case TypeOfItem.ProductVariant:
                        writer.WriteValue("variant");
                        break;
                    case TypeOfItem.Shipment:
                        writer.WriteValue("shipment");
                        break;
                    case TypeOfItem.Payment:
                        writer.WriteValue("payment");
                        break;
                    case TypeOfItem.Rebate:
                        writer.WriteValue("rebate");
                        break;
                    case TypeOfItem.ConfiguredProduct:
                        writer.WriteValue("productConfiguration");
                        break;
                    case TypeOfItem.BomProduct:
                        writer.WriteValue("bom");
                        break;
                    case TypeOfItem.Coupon:
                        writer.WriteValue("coupon");
                        break;
                    case TypeOfItem.Deal:
                        writer.WriteValue("offer");
                        break;
                    case TypeOfItem.DealLine:
                        writer.WriteValue("offerLine");
                        break;
                    case TypeOfItem.GiftCard:
                        writer.WriteValue("giftCard");
                        break;
                    default:
                        writer.WriteValue($"Unknown_{mk.TypeOfItem}");
                        break;
                }

                writer.WriteEndObject();
            }
        }
    }
}