using System.Text.Json;
using System.Text.Json.Serialization;

namespace OLDumpHelper.Converter
{
    /// <summary>
    /// Custom converter for 'Description' property in the Work class
    /// </summary>
    public class DescriptionConverter : JsonConverter<string>
    {
        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string? description = null;

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return description;

                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        string? propertyName = reader.GetString();

                        switch (propertyName)
                        {
                            case "/type/text":
                                break;
                            default:
                                description = propertyName;
                                break;
                        }
                    }
                }
            }
            else
            {
                description = reader.GetString() ?? string.Empty;
            }

            return description;
        }

        public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
