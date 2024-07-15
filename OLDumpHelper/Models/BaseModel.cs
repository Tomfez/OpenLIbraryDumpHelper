using System.Text.Json.Serialization;

namespace OLDumpHelper.Models
{
    public class BaseModel
    {
    }

    public class StringType
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;
    }

 

    public class LastModified
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("value")]
        public DateTime Value { get; set; } = default!;
    }
}
