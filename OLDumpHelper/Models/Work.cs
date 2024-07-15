using OLDumpHelper.Converter;
using System.Text.Json.Serialization;

namespace OLDumpHelper.Models
{
    /// <summary>
    /// Work model class
    /// </summary>
    public class Work : BaseModel
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;

        [JsonPropertyName("title")]
        public string Title { get; set; } = default!;

        [JsonPropertyName("subtitle")]
        public string Subtitle { get; set; } = default!;

        [JsonPropertyName("type")]
        public ObjectType Type { get; set; } = default!;

        [JsonPropertyName("subjects")]
        public string[]? Subjects { get; set; }

        [JsonPropertyName("authors")]
        public AuthorsWork[] Authors { get; set; } = [];

        [JsonPropertyName("covers")]
        public int[] Covers { get; set; } = [];

        [JsonPropertyName("first_publish_date")]
        public string? FirstPublishDate { get; set; }

        [JsonPropertyName("description")]
        [JsonConverter(typeof(DescriptionConverter))]
        public string? Description { get; set; }

        [JsonPropertyName("revision")]
        public int Revision { get; set; }

        [JsonPropertyName("latest_revision")]
        public int LatestRevision { get; set; }

        [JsonPropertyName("created")]
        public LastModified Created { get; set; } = default!;

        [JsonPropertyName("last_modified")]
        public LastModified LastModified { get; set; } = default!;
    }

    public class AuthorsWork
    {
        [JsonPropertyName("type")]
        [JsonConverter(typeof(WorkTypeConverter))]
        public ObjectType Type { get; set; } = default!;

        [JsonPropertyName("author")]
        [JsonConverter(typeof(AuthorKeyConverter))]
        public AuthorKey Author { get; set; } = default!;
    }

    public class AuthorKey
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = string.Empty;
    }

    public class ObjectType
    {
        [JsonPropertyName("key")]
        public string Key { get; set; } = default!;
    }
}
