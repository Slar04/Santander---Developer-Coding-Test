using Newtonsoft.Json;

namespace SantanderDeveloperCodingTest.Model.Converters
{
    public class UnixTimeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(string);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Integer)
            {
                long unixTime = Convert.ToInt64(reader.Value);
                DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTime);
                return dateTimeOffset.ToString("yyyy-MM-ddTHH:mm:sszzz");
            }

            throw new JsonSerializationException("Invalid Unix time format.");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is string dateString && DateTimeOffset.TryParse(dateString, out DateTimeOffset dto))
            {
                writer.WriteValue(dto.ToUnixTimeSeconds());
            }
            else
            {
                throw new JsonSerializationException("Expected valid ISO 8601 date string.");
            }
        }
    }
}
