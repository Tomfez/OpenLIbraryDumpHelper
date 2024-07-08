using System.Text.Json;
using System.Text.Json.Serialization;

namespace OLDumpHelper
{
    public class CustomJsonConverter : JsonConverter<string>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                return reader.GetString() ?? String.Empty;
            }
            else if (reader.TokenType == JsonTokenType.StartObject)
            {
                reader.Skip();
                return ("not supported");
            }
            else
            {
                return null;
            }
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value);
        }
    }
}
