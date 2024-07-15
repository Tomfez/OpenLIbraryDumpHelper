using OLDumpHelper.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OLDumpHelper.Converter
{
    /// <summary>
    /// Custom converter for 'AuthorKey' property in the Author class
    /// </summary>
    public class AuthorKeyConverter : JsonConverter<AuthorKey>
    {
        public override AuthorKey Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            AuthorKey authorKey = new AuthorKey();

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return authorKey;

                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        string? keyValue = reader.GetString();
                        authorKey.Key = keyValue ?? string.Empty;
                    }
                }
            }
            else
            {
                authorKey.Key = reader.GetString() ?? string.Empty;
            }

            return authorKey;
        }

        public override void Write(Utf8JsonWriter writer, AuthorKey value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, value.GetType(), options);
        }
    }
}
