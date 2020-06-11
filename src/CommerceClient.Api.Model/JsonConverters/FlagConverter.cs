// Flemming Rothmann

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace CommerceClient.Api.Model.JsonConverters
{
    public class FlagConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanRead => true;

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer
        )
        {
            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            if (objectType == null)
            {
                throw new ArgumentNullException(nameof(objectType));
            }

            if (existingValue == null)
            {
                throw new ArgumentNullException(nameof(existingValue));
            }

            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            if (objectType.IsGenericType && objectType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                objectType = objectType.GetGenericArguments().First();
            }

            string strValue;
            if (reader.TokenType == JsonToken.StartArray)
            {
                var stringList = new List<string>();
                while (reader.Read() && reader.TokenType != JsonToken.EndArray)
                {
                    if (reader.Value is string valueString)
                    {
                        stringList.Add(valueString);
                    }
                }

                strValue = string.Join(
                    ",",
                    stringList
                );
            }
            else
            {
                strValue = reader.Value as string ?? string.Empty;
            }

            return Enum.Parse(
                objectType,
                strValue,
                true
            );
        }

        /// <inheritdoc />
        public override bool CanWrite => true;

        public override void WriteJson(
            JsonWriter writer,
            object value,
            JsonSerializer serializer
        )
        {
            if (writer == null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (serializer == null)
            {
                throw new ArgumentNullException(nameof(serializer));
            }

            var allValues = Enum.GetValues(value.GetType());
            var setValues = (from object flag in allValues
                             where (int) flag != 0 && ((int) value & (int) flag) != 0
                             select $"\"{flag.ToString()}\"").ToList();

            writer.WriteRawValue($"[{string.Join(", ", setValues)}]");


            //var flags = value.ToString()
            //    .Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries)
            //    .Select(f => $"\"{f}\"");

            //writer.WriteRawValue($"[{string.Join(", ", flags)}]");
        }

        public override bool CanConvert(Type objectType)
            => objectType?.IsEnum == true &&
               objectType.GetCustomAttributes(typeof(FlagsAttribute))
                   .FirstOrDefault() !=
               null;
    }
}