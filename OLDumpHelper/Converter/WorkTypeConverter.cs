using OLDumpHelper.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OLDumpHelper.Converter
{
    /// <summary>
    /// Custom converter for 'ObjectProperty' in the Work class
    /// </summary>
    public class WorkTypeConverter : JsonConverter<ObjectType>
    {
        public override ObjectType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            ObjectType objectType = new ObjectType();

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return objectType;

                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        string? keyValue = reader.GetString();
                        objectType.Key = keyValue ?? string.Empty;
                    }
                }
            }
            else
            {
                objectType.Key = reader.GetString() ?? string.Empty;
            }

            return objectType;
        }

        public override void Write(Utf8JsonWriter writer, ObjectType value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
