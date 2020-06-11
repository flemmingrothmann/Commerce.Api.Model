using System;
using System.IO;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;

namespace CommerceClient.Api.Online
{
    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        private JsonSerializer serializer;

        public NewtonsoftJsonSerializer(JsonSerializer serializer) => this.serializer = serializer;

        public string ContentType
        {
            get => "application/json"; // Probably used for Serialization?
            set { }
        }

        public string DateFormat { get; set; }

        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    serializer.Serialize(
                        jsonTextWriter,
                        obj
                    );

                    return stringWriter.ToString();
                }
            }
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            if (response == null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        public static NewtonsoftJsonSerializer Default =>
            new NewtonsoftJsonSerializer(
                new JsonSerializer()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                }
            );
    }
}